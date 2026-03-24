int menu = 0;

int total = 0;
int publicados = 0;
int rechazados = 0;
int revision = 0;

int impactoAlto = 0;
int impactoMedio = 0;
int impactoBajo = 0;

do
{

    Console.WriteLine(" ");
    Console.WriteLine("Selecciona una opción en número: ");
    Console.WriteLine("1. Evaluar nuevo contenido. ");
    Console.WriteLine("2. Mostrar reglas del sistema. ");
    Console.WriteLine("3. Mostrar estadísticas de la sesión. ");
    Console.WriteLine("4. Reiniciar estadísticas. ");
    Console.WriteLine("5. Salir. ");
    Console.WriteLine(" ");

    switch (menu)
    {
        case 1: //evaluar nuevo contenido

            total++;

            bool valido = true;
            string razon = "";

            Console.WriteLine(" ");
            Console.WriteLine("Ingresa tipo de contenido. ");
            Console.WriteLine("Película, serie, documental o evento en vivo: ");
            string tipoDeContenido = Console.ReadLine().ToLower();

            Console.WriteLine(" ");
            Console.WriteLine("Ingresa duración (en minutos):  ");
            double duracionContenido = double.Parse(Console.ReadLine());

            Console.WriteLine(" ");
            Console.WriteLine("Ingrese clasificación. ");
            Console.WriteLine("Todo público, +13 o +18: ");
            string clasificacionContenido = Console.ReadLine().ToLower();

            Console.WriteLine(" ");
            Console.WriteLine("Ingrese hora programada. ");
            Console.WriteLine("0-23: ");
            int horaContenido = int.Parse(Console.ReadLine());

            Console.WriteLine(" ");
            Console.WriteLine("Ingrese nivel de producción: ");
            Console.WriteLine("bajo, medio o alto: ");
            string produccionContenido = Console.ReadLine().ToLower();


            

            if (clasificacionContenido == "+13")
            {
                if (!(horaContenido >= 6 && horaContenido <= 22)) //no puede ser diferente
                {
                    valido = false;
                    razon = "Horario invalido para +13";
                }
            }

            if (clasificacionContenido == "+18")
            {
                if (!(horaContenido >= 22 && horaContenido <= 5))
                {
                    valido = false;
                    razon = "Horario invalido para +18";
                }
            }

            //todo publico, cualquier hora.




            if (tipoDeContenido == "pelicula" || tipoDeContenido == "película")
            {
                if (!(duracionContenido >= 60 && duracionContenido <= 180))
                {
                    valido = false;
                    razon = "Duración invalida para película";
                }
            }

            if (tipoDeContenido == "serie")
            {
                if (!(duracionContenido >= 20 && duracionContenido <= 90))
                {
                    valido = false;
                    razon = "Duración invalida para serie";
                }
            }

            if (tipoDeContenido == "documental")
            {
                if (!(duracionContenido >= 30 && duracionContenido <= 120))
                {
                    valido = false;
                    razon = "Duración invalida para documental";
                }
            }

            if (tipoDeContenido == "evento en vivo")
            {
                if (!(duracionContenido >= 30 && duracionContenido <= 240))
                {
                    valido = false;
                    razon = "Duración invalida para evento";
                }
            }




            if (produccionContenido == "bajo")
            {
                if (clasificacionContenido == "+18")
                {
                    valido = false;
                    razon = "Producción baja no valida para +18";
                }
            }



            if (!valido)
            {
                rechazados++;
                Console.WriteLine(" ");
                Console.WriteLine("Rechazado. ");
                Console.WriteLine("Razón: " + razon);
                break;
            }


            break;




        case 2: //mostrar reglas del sistema
            break;




        case 3: //mostrar estadísticas de la sesión
            break;




        case 4: //reiniciar
            break;

    }
    } while (menu != 5);