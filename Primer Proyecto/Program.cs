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


    while (!int.TryParse(Console.ReadLine(), out menu))
    {
        Console.WriteLine("Ingrese un número valido.");
    }


    switch (menu)
    {
        case 1: //evaluar nuevo contenido

            total++;

            bool valido = true;
            bool ajuste = false;
            string razon = " ";

            //solocitar datos

            Console.WriteLine(" ");
            Console.WriteLine("Ingresa tipo de contenido. ");
            Console.WriteLine("Película, serie, documental o evento en vivo: ");
            string tipoDeContenido = Console.ReadLine().ToLower(); //convertir a minuscula automaticamente

            Console.WriteLine(" ");
            Console.WriteLine("Ingresa duración (en minutos):  ");
            double duracionContenido;
            while (!double.TryParse(Console.ReadLine(), out duracionContenido))
            {
                Console.WriteLine("Ingrese número valido.");
            }

            Console.WriteLine(" ");
            Console.WriteLine("Ingrese clasificación. ");
            Console.WriteLine("Todo público, +13 o +18: ");
            string clasificacionContenido = Console.ReadLine().ToLower();

            Console.WriteLine(" ");
            Console.WriteLine("Ingrese hora programada. ");
            Console.WriteLine("0-23: ");
            int horaContenido;
            while (!int.TryParse(Console.ReadLine(), out horaContenido))
            {
                Console.WriteLine("Ingrese número valido.");
            }

            Console.WriteLine(" ");
            Console.WriteLine("Ingrese nivel de producción: ");
            Console.WriteLine("bajo, medio o alto: ");
            string produccionContenido = Console.ReadLine().ToLower();



            //reglas de publicacion

            //+13
            if (clasificacionContenido == "+13") 
            {
                if (!(horaContenido >= 6 && horaContenido <= 22)) //no puede ser diferente
                {
                    if (horaContenido == 5 || horaContenido == 23) //ajustes minimos
                    {
                        ajuste = true;
                        razon = "Ajustar horario para +13";
                    }
                    else
                    {
                        valido = false;
                        razon = "Horario invalido para +13";
                    }
                 }
                }

            //+18
            if (clasificacionContenido == "+18")
            {
               if (!(horaContenido >= 22 && horaContenido <= 5))
                {
                    if (horaContenido == 21 || horaContenido == 6)
                    {
                        ajuste = true;
                        razon = "Ajustar horario para +18";
                    }
                    else
                    {
                        valido = false;
                        razon = "Horario invalido para +18";
                    }
                }
            }

            //todo publico, cualquier hora.



            //duraciones

            //pelicula
            if (tipoDeContenido == "pelicula" || tipoDeContenido == "película")
            {
                if (!(duracionContenido >= 60 && duracionContenido <= 180))
                {
                    if (duracionContenido >= 50 && duracionContenido <= 190)
                    {
                        ajuste = true;
                        razon = "Ajustar duración para película";
                    }
                    else
                    {
                        valido = false;
                        razon = "Duración invalida para película";
                    }
                }
            }

            //serie
            if (tipoDeContenido == "serie")
            {
                if (!(duracionContenido >= 20 && duracionContenido <= 90))
                {
                    if (duracionContenido >= 15 && duracionContenido <= 100)
                    {
                        ajuste = true;
                        razon = "Ajustar duración para serie";
                    }
                    else
                    {
                        valido = false;
                        razon = "Duración invalida para serie";
                    }
                }
            }

            //documental
            if (tipoDeContenido == "documental")
            {
                if (!(duracionContenido >= 30 && duracionContenido <= 120))
                {
                    if (duracionContenido >= 25 && duracionContenido <= 130)
                    {
                        ajuste = true;
                        razon = "Ajustar duración para documental";
                    }
                    else
                    {
                        valido = false;
                        razon = "Duración invalida para documental";
                    }
                }
            }

            //evento en vivo
            if (tipoDeContenido == "evento en vivo")
            {
                if (!(duracionContenido >= 30 && duracionContenido <= 240))
                {
                    if (duracionContenido >= 25 && duracionContenido <= 250)
                    {
                        ajuste = true;
                        razon = "Ajustar duración para evento";
                    }
                    else
                    {
                        valido = false;
                        razon = "Duración invalida para evento";
                    }
                }
            }


            //produccion 


            if (produccionContenido == "bajo")
            {
                if (clasificacionContenido == "+18")
                {
                    valido = false;
                    razon = "Producción baja no valida para +18";
                }
            }


            //si fue la variable valido se guarda en reechazados
            if (!valido)
            {
                rechazados++;
                Console.WriteLine(" ");
                Console.WriteLine("Rechazado. ");
                Console.WriteLine("Razón: " + razon);
                break; //no pasa a impacto, sale del case 1 
            }




            string impacto = "Bajo"; //variable impacto

            if (produccionContenido == "alto" || duracionContenido > 120 || (horaContenido >= 20 && horaContenido <= 23))
            {
                impacto = "Alto";
                impactoAlto++;
            }
            else if (produccionContenido == "medio" || (duracionContenido >= 60 && duracionContenido <= 120))
            {
                impacto = "Medio";
                impactoMedio++;
            }
            else
            {
                impactoBajo++;
            }




            if (impacto == "Alto")
            {
                revision++;
                Console.WriteLine(" ");
                Console.WriteLine("Enviar a revisión.");
                Console.WriteLine("Razón: Impacto alto.");
            }
            else
            {
                publicados++;


                if (ajuste)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Publicar con ajustes.");
                    Console.WriteLine("Razón: " + razon);
                }
                else
                {
                    Console.WriteLine("Publicar.");
                    Console.WriteLine("Razón: Impacto " + impacto);
                }
            }




            break;




        case 2: //mostrar reglas del sistema

            Console.WriteLine("REGLAS DEL SISTEMA: ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("1. CLASIFICACIÓN Y HORARIO: ");
            Console.WriteLine("Todo público: cualquier hora.");
            Console.WriteLine("+13: entre 6 y 22 horas.");
            Console.WriteLine("+18: entre 22 y 5 horas.");
            Console.WriteLine(" ");
            Console.WriteLine("2. DURACIÓN POR TIPO: ");
            Console.WriteLine("Película: 60 a 180 minutos.");
            Console.WriteLine("Serie: 20 a 90 minutos.");
            Console.WriteLine("Documental: 30 a 120 minutos.");
            Console.WriteLine("Evento en vivo: 30 a 240 minutos.");
            Console.WriteLine(" ");
            Console.WriteLine("3. PRODUCCIÓN:");
            Console.WriteLine("Producción baja: solo valida para todo público o +13.");
            Console.WriteLine("Producción media o alta: válida para cualquiera.");
            Console.WriteLine(" ");
            Console.WriteLine("4. IMPACTO:");
            Console.WriteLine("Alto: producción alta, duración mayor a 120 o entre 20 y 23 horas.");
            Console.WriteLine("Medio: producción media o duración entre 60 y 120 minutos.");
            Console.WriteLine("Bajo: producción baja y duración menor a 60 minutos.");
            Console.WriteLine(" ");
            Console.WriteLine("5. DECISIONES:");
            Console.WriteLine("Publicar: cumple reglas técnicas e impacto bajo o medio.");
            Console.WriteLine("Publicar con ajustes: requiere cambios menores.");
            Console.WriteLine("Enviar a revisión: impacto alto.");
            Console.WriteLine("Rechazar: incumple reglas obligatorias.");


            break;

            


        case 3: //mostrar estadísticas de la sesión

            Console.WriteLine(" ");
            Console.WriteLine("Total evaluados: " + total);
            Console.WriteLine("Publicados: " + publicados);
            Console.WriteLine("Rechazados: " + rechazados);
            Console.WriteLine("En revisión: " + revision);

            string predominante = "Bajo";

            if (impactoAlto > impactoMedio && impactoAlto > impactoBajo)
            {
                predominante = "Alto";
            }
            else if (impactoMedio > impactoBajo)
            {
                predominante = "Medio";
            }




            Console.WriteLine("Impacto predominante: " + predominante);

            double porcentaje = 0;

            if (total > 0)
            {
                porcentaje = (publicados * 100.0)/total;
            }

            Console.WriteLine("Porcentaje de aprobación: " + porcentaje + "%");
            Console.WriteLine(" ");




            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Fin de estadísticas. ");
            }

            break;




        case 4: //reiniciar


            total = 0;
            publicados = 0;
            rechazados = 0;
            revision = 0;
            impactoAlto = 0;
            impactoMedio = 0;
            impactoBajo = 0; //para reinciar todos los datos

            Console.WriteLine(" ");
            Console.WriteLine("Datos reiniciados. ");


            break;

    }
    } while (menu != 5);


Console.WriteLine(" ");
Console.WriteLine("Resumen final:");
Console.WriteLine(" ");
Console.WriteLine("Total evaluados: " + total);
Console.WriteLine("Publicados: " + publicados);
Console.WriteLine("Rechazados: " + rechazados);
Console.WriteLine("En revisión: " + revision);


//agregar todo de nuevo

string predominanteFinal = "Bajo";

if (impactoAlto > impactoMedio && impactoAlto > impactoBajo)
{
    predominanteFinal = "Alto";
}
else if (impactoMedio > impactoBajo)
{
    predominanteFinal = "Medio";
}

Console.WriteLine("Impacto predominante: " + predominanteFinal);

double porcentajeFinal = 0;

if (total > 0)
{
    porcentajeFinal = (publicados * 100.0)/total;
}

Console.WriteLine("Porcentaje de aprobación: " + porcentajeFinal + "%");
