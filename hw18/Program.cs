namespace hw18
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("All commands: create, delete, info, size, exit");
                Console.Write("Input command: ");
                string command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "create":
                        createItem();
                        break;
                    case "delete":
                        deleteItem();
                        break;
                    case "info":
                        showInfo();
                        break;
                    case "size":
                        showSize();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Wrong command");
                        break;
                }
                Console.Clear();
            }
        }
        public static void createItem()
        {
            Console.Write("Create file or directory(file/dir): ");
            string type = Console.ReadLine();

            Console.Write("Input path(if file, input with file name): ");
            string path = Console.ReadLine();

            if (type.ToLower() == "file")
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    return;
                }
            }
            else if (type.ToLower() == "dir")
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid type");
            }
        }
        public static void deleteItem()
        {
            Console.Write("Delete file or directory(file/dir): ");
            string type = Console.ReadLine();

            Console.Write("Input path(if file, input with file name): ");
            string path = Console.ReadLine();

            if (type.ToLower() == "file")
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return;
                }
            }
            else if (type.ToLower() == "dir")
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path);
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid type");
            }
        }
        public static void showInfo()
        {
            Console.Write("Input path to file: ");
            string path = Console.ReadLine();
            if (File.Exists(path))
            {
                FileInfo info = new FileInfo(path);
                Console.WriteLine($"Name: {info.Name}");
                Console.WriteLine($"Size: {info.Length}");
                Console.WriteLine($"Creation time: {info.CreationTime}");
            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }
            Console.ReadKey();
        }
        public static void showSize()
        {
            Console.Write("Input path to directory: ");
            string path = Console.ReadLine();
            if (Directory.Exists(path))
            {
                long size = 0;
                foreach (string file in Directory.GetFiles(path))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    size += fileInfo.Length;
                }
                Console.WriteLine(size + "bytes");
            }
            else
            {
                Console.WriteLine("Directory doesn't exist");
            }
            Console.ReadKey();

        }
    }
}
