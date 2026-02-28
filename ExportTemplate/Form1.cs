using System.Text;

namespace ExportTemplate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtPasta.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPasta.Text) || string.IsNullOrEmpty(txtNomeProjeto.Text))
            {
                MessageBox.Show("Preencha todos os campos");
                return;
            }

            string currentDirectory = Directory.GetCurrentDirectory();
            string pastaPai = FindDirectoryContainingSrc(currentDirectory);

            if (pastaPai != null)
            {
                string targetDirectory = Path.Combine(txtPasta.Text, txtNomeProjeto.Text);
                Directory.CreateDirectory(targetDirectory);
                CopyDirectory(pastaPai, targetDirectory);
                RenameProjectNameFolders(Path.Combine(targetDirectory, "src"), txtNomeProjeto.Text);
                RenameProjectNameFiles(targetDirectory, txtNomeProjeto.Text);
                ReplaceProjectNameInFiles(targetDirectory, txtNomeProjeto.Text);
                MessageBox.Show("Projeto gerado com sucesso!");
            }
        }

        private string FindDirectoryContainingSrc(string startDirectory)
        {
            string currentDirectory = startDirectory;

            while (!string.IsNullOrEmpty(currentDirectory))
            {
                string potentialSrcPath = Path.Combine(currentDirectory, "src");
                if (Directory.Exists(potentialSrcPath))
                {
                    return currentDirectory;
                }

                currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
            }

            return null;
        }

        private void CopyDirectory(string sourceDir, string targetDir)
        {
            foreach (var dirPath in Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
            {
                if (!ShouldExcludeDirectory(dirPath))
                {
                    Directory.CreateDirectory(dirPath.Replace(sourceDir, targetDir));
                }
            }

            foreach (var newPath in Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories))
            {
                if (!ShouldExcludeFile(newPath))
                {
                    File.Copy(newPath, newPath.Replace(sourceDir, targetDir), true);
                }
            }
        }

        private bool ShouldExcludeDirectory(string dirPath)
        {
            string[] excludedDirs = { ".git", ".vs", "obj", "bin", "ExportTemplate" };
            return excludedDirs.Any(excludedDir => dirPath.Contains(excludedDir));
        }

        private bool ShouldExcludeFile(string filePath)
        {
            return filePath.EndsWith("README.md") || ShouldExcludeDirectory(Path.GetDirectoryName(filePath));
        }

        private void RenameProjectNameFolders(string srcDirectory, string newProjectName)
        {
            foreach (var dirPath in Directory.GetDirectories(srcDirectory, "*", SearchOption.AllDirectories))
            {
                string dirName = Path.GetFileName(dirPath);
                if (dirName.Contains("ProjectName"))
                {
                    string newDirName = dirName.Replace("ProjectName", newProjectName);
                    string newDirPath = Path.Combine(Path.GetDirectoryName(dirPath), newDirName);
                    Directory.Move(dirPath, newDirPath);
                }
            }
        }

        private void RenameProjectNameFiles(string srcDirectory, string newProjectName)
        {
            foreach (var filePath in Directory.GetFiles(srcDirectory, "*.*", SearchOption.AllDirectories))
            {
                string fileName = Path.GetFileName(filePath);
                if (fileName.Contains("ProjectName"))
                {
                    string newFileName = fileName.Replace("ProjectName", newProjectName);
                    string newFilePath = Path.Combine(Path.GetDirectoryName(filePath), newFileName);
                    File.Move(filePath, newFilePath);
                }
            }
        }

        private void ReplaceProjectNameInFiles(string srcDirectory, string newProjectName)
        {
            foreach (var filePath in Directory.GetFiles(srcDirectory, "*.*", SearchOption.AllDirectories))
            {
                string fileContent = File.ReadAllText(filePath, Encoding.UTF8);
                fileContent = fileContent.Replace("ProjectName", newProjectName);
                File.WriteAllText(filePath, fileContent);
            }
        }
    }
}
