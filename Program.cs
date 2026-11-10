Dictionary<int, string> marcas = new Dictionary<int, string>();
Dictionary<int, string> modelos = new Dictionary<int, string>();
Dictionary<int, bool> disponibles = new Dictionary<int, bool>();

Dictionary<int, string> nombres = new Dictionary<int, string>();
Dictionary<int, string> correos = new Dictionary<int, string>();

List<int> reservaIds = new List<int>();
List<int> reservaUsuarios = new List<int>();
List<int> reservaComputadoras = new List<int>();
List<DateTime> reservaFechas = new List<DateTime>();

int select = 0;
int idReserva = 1;

while (select != 7)
{
    try
    {
        Console.WriteLine("CONTROL DE RESERVAS DE COMPUTADORAS");

        Console.WriteLine("1. Registrar computadora");
        Console.WriteLine("2. Registrar usuario");
        Console.WriteLine("3. Reservar computadora");
        Console.WriteLine("4. Consultar disponibilidad");
        Console.WriteLine("5. Cancelar reserva");
        Console.WriteLine("6. Mostrar reservas");
        Console.WriteLine("7. Salir");

        Console.WriteLine("\nSelecciona una opción:");
        select = int.Parse(Console.ReadLine());

        switch (select)
        {
            case 1:
                {

                    Console.WriteLine("\nIngrese el ID de la computadora:");
                    int idComputadora = int.Parse(Console.ReadLine());

                    if (marcas.ContainsKey(idComputadora))
                    {
                        Console.WriteLine("Error: Esta computadora ya existe");
                    }
                    else
                    {
                        Console.WriteLine("Ingrese la marca:");
                        string marca = Console.ReadLine();

                        Console.WriteLine("Ingrese el modelo:");
                        string modelo = Console.ReadLine();

                        marcas.Add(idComputadora, marca);
                        modelos.Add(idComputadora, modelo);
                        disponibles.Add(idComputadora, true);

                        Console.WriteLine("Computadora registrada correctamente");
                    }

                    break;
                }

            case 2:
                {
                    Console.WriteLine("\nIngrese el ID del usuario:");
                    int idUsuario = int.Parse(Console.ReadLine());

                    if (nombres.ContainsKey(idUsuario))
                    {
                        Console.WriteLine("Error: Este usuario ya existe");
                    }
                    else
                    {
                        Console.WriteLine("Ingrese el nombre:");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese el correo:");
                        string correo = Console.ReadLine();

                        nombres.Add(idUsuario, nombre);
                        correos.Add(idUsuario, correo);

                        Console.WriteLine("Usuario registrado correctamente");
                    }

                    break;
                }

            case 3:
                { 
                Console.WriteLine("\nIngrese el ID del usuario:");
                int usuarioReserva = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el ID de la computadora:");
                int computadoraReserva = int.Parse(Console.ReadLine());

                if (nombres.ContainsKey(usuarioReserva) &&
                    marcas.ContainsKey(computadoraReserva))
                {
                    if (disponibles[computadoraReserva] == true)
                    {
                        reservaIds.Add(idReserva);
                        reservaUsuarios.Add(usuarioReserva);
                        reservaComputadoras.Add(computadoraReserva);
                        reservaFechas.Add(DateTime.Now);

                        disponibles[computadoraReserva] = false;

                        Console.WriteLine("Reserva realizada correctamente");
                        Console.WriteLine($"Número de reserva: {idReserva}");

                        idReserva++;
                    }
                    else
                    {
                        Console.WriteLine("Error: La computadora no está disponible");
                    }
                }
                else
                {
                    Console.WriteLine("Error: El usuario o la computadora no existen");
                }

                break;
                }

            case 4:
                { 
                if (marcas.Count > 0)
                {
                    Console.WriteLine("\nCOMPUTADORAS REGISTRADAS");

                    foreach (var id in marcas.Keys)
                    {
                        Console.WriteLine($"ID: {id}");
                        Console.WriteLine($"Marca: {marcas[id]}");
                        Console.WriteLine($"Modelo: {modelos[id]}");

                        if (disponibles[id] == true)
                        {
                            Console.WriteLine("Estado: Disponible");
                        }
                        else
                        {
                            Console.WriteLine("Estado: Reservada");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No hay computadoras registradas");
                }

                break;
                }

            case 5:
                { 
                Console.WriteLine("Ingrese el número de reserva:");
                int reservaCancelar = int.Parse(Console.ReadLine());

                int posicion = reservaIds.IndexOf(reservaCancelar);

                if (posicion != -1)
                {
                    int computadoraLiberar = reservaComputadoras[posicion];

                    disponibles[computadoraLiberar] = true;

                    reservaIds.RemoveAt(posicion);
                    reservaUsuarios.RemoveAt(posicion);
                    reservaComputadoras.RemoveAt(posicion);
                    reservaFechas.RemoveAt(posicion);

                    Console.WriteLine("Reserva cancelada correctamente");
                }
                else
                {
                    Console.WriteLine("Error: La reserva no existe");
                }

                break;
                }

            case 6:
                { 
                if (reservaIds.Count > 0)
                {
                    Console.WriteLine("\nRESERVAS REGISTRADAS");

                    for (int i = 0; i < reservaIds.Count; i++)
                    {
                        int u = reservaUsuarios[i];
                        int c = reservaComputadoras[i];

                        Console.WriteLine($"Reserva: {reservaIds[i]}");
                        Console.WriteLine($"Usuario: {nombres[u]}");
                        Console.WriteLine($"Computadora: {marcas[c]}");
                        Console.WriteLine($"Modelo: {modelos[c]}");
                        Console.WriteLine($"Fecha: {reservaFechas[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("No hay reservas registradas");
                }

                break;
                }

            case 7:
                { 
                Console.WriteLine("Cerrando el sistema...");

                break;
                }
            default:
                { 
                Console.WriteLine("Error: Opción no válida");

                break;
                }
        }
    }
    catch
    {
        Console.WriteLine("Error: Debes ingresar un dato válido");
    }
}