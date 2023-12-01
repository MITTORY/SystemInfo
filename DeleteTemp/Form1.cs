using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.IO;
using System.Windows.Forms;
using System.Management;
using System.Linq;
using System.Text;

namespace DeleteTemp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Обновление информации о системе
            string systemName = GetSystemName();
            nameSystem1.Text = systemName;

            // Обновление информации о разрядности системы
            string systemBitness = GetSystemBitness();
            textBox51.Text = systemBitness;

            // Обновление информации о пользователе
            //string userProfileName = GetUserProfileName();
            textBox41.Text = siticoneDeviceInfo1.GetSystemCaption;

            // Информация о материнской плате
            mother1.Text = siticoneDeviceInfo1.GetManufacturer;
            mother2.Text = siticoneDeviceInfo1.GetManufacturerModel;

            // Обновление информации о GPU
            string gpuInfo = GetGPUInfo();
            textBox11.Text = gpuInfo;

            // Обновление информации о процессоре
            string processorInfo = GetProcessorInfo();
            textBox21.Text = siticoneDeviceInfo1.GetProcessorName;

            // Обновление информации об оперативной памяти
            string ramInfo = GetRAMInfo();
            textBox31.Text = ramInfo;

            PopulateDriveComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tempFolderPath = @"C:\Users\Aydar\AppData\Local\Temp";
            int deletedFileCount = 0;
            int deletedFolderCount = 0;
            long totalDeletedSize = 0;

            try
            {
                // Удаление файлов
                string[] files = Directory.GetFiles(tempFolderPath);
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    try
                    {
                        totalDeletedSize += fileInfo.Length;
                        fileInfo.Delete();
                        deletedFileCount++;
                    }
                    catch (IOException)
                    {
                        // Файл используется другим приложением, пропускаем его
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Нет разрешения на удаление файла, пропускаем его
                    }
                }

                // Удаление папок
                string[] folders = Directory.GetDirectories(tempFolderPath);
                foreach (string folder in folders)
                {
                    DirectoryInfo folderInfo = new DirectoryInfo(folder);
                    try
                    {
                        folderInfo.Delete(true); // Рекурсивное удаление папки и ее содержимого
                        deletedFolderCount++;
                    }
                    catch (IOException)
                    {
                        // Папка или ее содержимое используется другим приложением, пропускаем ее
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Нет разрешения на удаление папки, пропускаем ее
                    }
                }

                double totalDeletedSizeMB = (double)totalDeletedSize / 1048576; // Конвертируем в мегабайты
                MessageBox.Show($"Успешно удалено {deletedFileCount} файлов и {deletedFolderCount} папок. \nОбщий размер удаленных файлов: {totalDeletedSizeMB:F2} МБ", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при удалении файлов и папок: \n" + ex.Message, "Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Users\\Aydar\\AppData\\Local\\Temp");
        }

        private void cpuLabel_Click(object sender, EventArgs e)
        {
            string processorInfo = GetProcessorInfo();
            // Теперь вы можете использовать полученную информацию, например, отобразить её на метке.
            MessageBox.Show("Процессор: " + processorInfo);
        }

        private string GetProcessorInfo()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj["Name"].ToString();
                }
            }
            return "Нет данных";
        }

        private string GetRAMInfo()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    ulong ramSize = Convert.ToUInt64(obj["TotalVisibleMemorySize"]);
                    // Конвертируем в гигабайты и форматируем строку
                    return $"{ramSize / (1024 * 1024)} ГБ"; // Используем мегабайты, так как оперативная память часто выражается в мегабайтах в контексте ОС.
                }
            }
            return "Нет данных";
        }

        private string GetGPUInfo()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj["Name"].ToString();
                }
            }
            return "Нет данных";
        }

        private string GetSystemName()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj["Caption"].ToString();
                }
            }
            return "Нет данных";
        }

        private string GetSystemBitness()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    // Получение разрядности операционной системы
                    string osArchitecture = obj["OSArchitecture"].ToString();

                    // Возвращаем разрядность
                    return osArchitecture;
                }
            }
            return "Нет данных";
        }

        private void DiskBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Get the selected drive letter
                string selectedDrive = DiskBox1.SelectedItem.ToString();

                // Get drive info
                DriveInfo driveInfo = new DriveInfo(selectedDrive);

                zanyato1.Visible = true;
                svobodno1.Visible = true;
                DiskName1.Visible = true;
                label181.Visible = true;
                label191.Visible = true;

                // Display drive info in TextBoxes
                MAX1.Text = $"{driveInfo.TotalSize / (1024 * 1024 * 1024)} GB"; // Total size in GB
                zanyato1.Text = $"{(driveInfo.TotalSize - driveInfo.TotalFreeSpace) / (1024 * 1024 * 1024)} GB"; // Used space in GB
                svobodno1.Text = $"{driveInfo.AvailableFreeSpace / (1024 * 1024 * 1024)} GB"; // Free space in GB
                DiskName1.Text = driveInfo.VolumeLabel; // Drive name
            }
            catch (IOException ex)
            {
                // Handle the IOException
                MAX1.Text = $"Ошибка: {ex.Message}";
                zanyato1.Visible = false;
                svobodno1.Visible = false;
                DiskName1.Visible = false;
                label191.Visible = false;
                label181.Visible = false;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                MAX1.Text = $"Произошла ошибка: {ex.Message}";
            }
        }

        private void PopulateDriveComboBox()
        {
            // Get all available drives
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Populate the DiskBox combo box
            foreach (DriveInfo drive in drives)
            {
                DiskBox1.Items.Add(drive.Name);
            }

            // Select the first drive by default if available
            if (DiskBox1.Items.Count > 0)
            {
                DiskBox1.SelectedIndex = 0;
            }
        }

        private void perefButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Запуск диспетчера устройств
                Process.Start("devmgmt.msc");
            }
            catch (Exception ex)
            {
                // Обработка возможных ошибок
                MessageBox.Show($"Произошла ошибка при открытии диспетчера устройств: {ex.Message}", "Ошибка");
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("ИНФОРМАЦИЯ О СИСТЕМЕ");

                sb.AppendLine("\n\nОперационная система:");
                sb.AppendLine(nameSystem1.Text);

                sb.AppendLine("\n\nРазрядность системы:");
                sb.AppendLine(textBox51.Text);

                sb.AppendLine("\n\nИмя устройства:");
                sb.AppendLine(textBox41.Text);

                sb.AppendLine("\n\nМатеринская плата:");
                sb.AppendLine("Мануфактура: " + mother1.Text);
                sb.AppendLine("Модель: " + mother2.Text);

                sb.AppendLine("\n\nВидеокарта:");
                sb.AppendLine(textBox11.Text);

                sb.AppendLine("\n\nПроцессор:");
                sb.AppendLine(textBox21.Text);

                sb.AppendLine("\n\nОперативная память:");
                sb.AppendLine(textBox31.Text);

                if (DiskBox1.SelectedIndex != -1)
                {
                    sb.AppendLine("\nИнформация о диске:");
                    sb.AppendLine($"Диск: {DiskBox1.SelectedItem.ToString()}");
                    sb.AppendLine($"Имя диска: {DiskName1.Text}");
                    sb.AppendLine($"Общий размер: {MAX1.Text}");
                    sb.AppendLine($"Занято: {zanyato1.Text}");
                    sb.AppendLine($"Свободно: {svobodno1.Text}");
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Text File";
                saveFileDialog.DefaultExt = "txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                    MessageBox.Show($"Данные о системе сохранены в {saveFileDialog.FileName}", "Успешно!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка!");
            }
        }
    }
}