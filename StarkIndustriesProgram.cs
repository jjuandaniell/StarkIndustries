using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            // mostrar menu de opciones
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Seleccione una opcion:");
            Console.WriteLine("1. Crear archivo");
            Console.WriteLine("2. Agregar invento");
            Console.WriteLine("3. Leer archivo linea por linea");
            Console.WriteLine("4. Leer todo el texto del archivo");
            Console.WriteLine("5. Copiar archivo");
            Console.WriteLine("6. Mover archivo");
            Console.WriteLine("7. Crear carpeta");
            Console.WriteLine("8. Listar archivos");
            Console.WriteLine("9. Verificar si existe un archivo");
            Console.WriteLine("10. Eliminar archivo");
            Console.WriteLine("11. Salir");
            string opcion = Console.ReadLine();

            // ejecutar la opcion seleccionada
            switch (opcion)
            {
                case "1":
                    CrearArchivo();
                    break;
                case "2":
                    Console.WriteLine("Ingrese el nombre del invento:");
                    string invento = Console.ReadLine();
                    AgregarInvento(invento);
                    break;
                case "3":
                    LeerArchivoLineaPorLinea();
                    break;
                case "4":
                    LeerTodoElArchivo();
                    break;
                case "5":
                    CopiarArchivo();
                    break;
                case "6":
                    MoverArchivo();
                    break;
                case "7":
                    Console.WriteLine("Ingrese el nombre de la carpeta:");
                    string nombreCarpeta = Console.ReadLine();
                    CrearCarpeta(nombreCarpeta);
                    break;
                case "8":
                    ListarArchivos();
                    break;
                case "9":
                    VerificarArchivo();
                    break;
                case "10":
                    EliminarArchivo();
                    break;
                case "11":
                    return;
                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }
        }
    }

    // crea un archivo con una lista de inventos
    static void CrearArchivo()
    {
        string path = "C:\\StarkIndustries\\StarkDirectory\\Inventos.txt";
        string[] inventos = {
            "1. Traje Mark I",
            "2. Reactor Arc",
            "3. Inteligencia Artificial JARVIS"
        };

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllLines(path, inventos);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Archivo 'inventos.txt' creado con exito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Error al crear el archivo: {ex.Message}");
        }
    }

    // agrega un invento al archivo existente
    static void AgregarInvento(string invento)
    {
        string path = "C:\\StarkIndustries\\StarkDirectory\\Inventos.txt";

        try
        {
            File.AppendAllText(path, $"{invento}{Environment.NewLine}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Invento '{invento}' agregado con exito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Error al agregar el invento: {ex.Message}");
        }
    }

    // lee el archivo linea por linea y muestra el contenido
    static void LeerArchivoLineaPorLinea()
    {
        string path = "C:\\StarkIndustries\\StarkDirectory\\Inventos.txt";

        try
        {
            string[] lineas = File.ReadAllLines(path);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Contenido del archivo linea por linea:");
            foreach (string linea in lineas)
            {
                Console.WriteLine(linea);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Error: El archivo 'inventos.txt' no existe. Ultron debe haberlo borrado!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Error al leer el archivo: {ex.Message}");
        }
    }

    // lee todo el contenido del archivo y lo muestra
    static void LeerTodoElArchivo()
    {
        string path = "C:\\StarkIndustries\\StarkDirectory\\Inventos.txt";

        try
        {
            string contenido = File.ReadAllText(path);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Contenido completo del archivo:");
            Console.WriteLine(contenido);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Error: El archivo 'inventos.txt' no existe. Ultron debe haberlo borrado!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Error al leer el archivo: {ex.Message}");
        }
    }

    // copia el archivo a la carpeta de copia de seguridad
    static void CopiarArchivo()
    {
        string origen = "C:\\StarkIndustries\\StarkDirectory\\Inventos.txt";
        string destino = "C:\\StarkIndustries\\StarkDirectory\\Copia de Seguridad\\inventos.txt";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destino));
            File.Copy(origen, destino, true);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Archivo copiado con exito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Error al copiar el archivo: {ex.Message}");
        }
    }

    // mueve el archivo a la carpeta ArchivosClasificados
    static void MoverArchivo()
    {
        string origen = "C:\\StarkIndustries\\StarkDirectory\\Inventos.txt";
        string destino = "C:\\StarkIndustries\\StarkDirectory\\ArchivosClasificados\\inventos.txt";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destino));
            File.Move(origen, destino);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Archivo movido con exito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Error al mover el archivo: {ex.Message}");
        }
    }

    // crea una nueva carpeta
    static void CrearCarpeta(string nombreCarpeta)
    {
        string path = $"C:\\StarkIndustries\\StarkDirectory\\{nombreCarpeta}";

        try
        {
            Directory.CreateDirectory(path);
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Carpeta '{nombreCarpeta}' creada con exito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Error al crear la carpeta: {ex.Message}");
        }
    }

    // lista todos los archivos en la carpeta LaboratorioAvengers
    static void ListarArchivos()
    {
        string path = "C:\\StarkIndustries\\StarkDirectory\\LaboratorioAvengers";

        try
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Carpeta 'LaboratorioAvengers' creada con exito.");
            }

            string[] archivos = Directory.GetFiles(path);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Archivos en la carpeta 'LaboratorioAvengers':");
            foreach (string archivo in archivos)
            {
                Console.WriteLine(Path.GetFileName(archivo));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Error al listar los archivos: {ex.Message}");
        }
    }

    // verifica si el archivo inventos.txt existe
    static void VerificarArchivo()
    {
        string path = "C:\\StarkIndustries\\StarkDirectory\\Inventos.txt";

        Console.WriteLine("--------------------------------");
        if (File.Exists(path))
        {
            Console.WriteLine("El archivo 'inventos.txt' existe.");
        }
        else
        {
            Console.WriteLine("El archivo 'inventos.txt' no existe.");
        }
    }

    // elimina el archivo despues de hacer una copia de seguridad
    static void EliminarArchivo()
    {
        string path = "C:\\StarkIndustries\\StarkDirectory\\Inventos.txt";
        string backupPath = "C:\\StarkIndustries\\StarkDirectory\\Copia de Seguridad\\inventos.txt";

        try
        {
            if (File.Exists(path))
            {
                File.Copy(path, backupPath, true);
                File.Delete(path);
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Archivo 'inventos.txt' eliminado despues de hacer una copia de seguridad.");
            }
            else
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("El archivo 'inventos.txt' no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Error al eliminar el archivo: {ex.Message}");
        }
    }
}
