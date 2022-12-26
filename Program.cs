using System.Diagnostics;

namespace Asincronia
{
    internal class Program
    {
        private static ushort time = 0;
        private static ushort timeAsync = 0;
        private static async Task Main(string[] args)
        {
            Console.Clear();
            // await HacerAlgo();
            //Console.WriteLine($"Esto es el Hilo Principal");
            // await Task.Delay(1000);
            // Console.WriteLine($"Ejercicios sobre Asincronia");
            //  DesayunoSinc();
            //await DesayunoAsync1();
            // await DesayunoAsync2();            
            // await DesayunoAsync3();
            await DesayunoAsync4();
        }
        //---------------Clases ------------------------------------------------
        public class Cafe { }
        public class Huevo { }
        public class Tostada { }
        public class Tocineta { }
        public class Jugo { }
        //-------------------  metodos varios
        private static async Task HacerAlgo()
        {
            Console.WriteLine($"Este es un subpoceso asincronico");
            await Task.Delay(4000);

        }
        private static void DesayunoSinc()
        {
            // Uso de Aync/await pero sin aplicar su filosofia 
            Stopwatch crono = new Stopwatch();
            crono.Start();
            Cafe posillo = PrepararCafe();
            Console.WriteLine("Cafe Listo");
            ushort numHuevos = 2;
            Huevo huevos = FritarHuevo(numHuevos);
            Console.WriteLine($"Listos los{numHuevos} Huevos ");

            Tocineta tocino = FritarTocineta(3);
            Console.WriteLine("Tocineta Lista");

            Tostada tostadas = TostarPan(2);
            PonerMermelada(tostadas);
            PonerMantequilla(tostadas);
            Console.WriteLine("Tostadas Lista ");

            Jugo miJugo = PrepararJugo("Corozo");
            Console.WriteLine("Listo el Jugo de ");
            Console.WriteLine("Al fin. Listo el Desayuno");
            crono.Stop();
            Console.WriteLine($"Tiempo Transcurrido SINCRONO => {crono.ElapsedMilliseconds / 1000} minutos");
        }

        private static async Task DesayunoAsync1()
        {
            Stopwatch crono = new Stopwatch();
            crono.Start();
            Cafe posillo = await PrepararCafeAsync();
            Console.WriteLine("Cafe Listo");
            ushort numHuevos = 2;
            Huevo huevos = await FritarHuevoAsync(numHuevos);
            Console.WriteLine($"Listos los {numHuevos} Huevos ");

            Tocineta tocino = await FritarTocinetaAsync(3);
            Console.WriteLine("Tocineta Lista");

            Tostada tostadas = await TostarPanAsync(2);
            PonerMermelada(tostadas);
            PonerMantequilla(tostadas);
            Console.WriteLine("Tostadas Lista ");

            Jugo miJugo = PrepararJugo("Guanabana en leche");
            Console.WriteLine($"Listo el Jugo de {miJugo}");
            Console.WriteLine("\nAl fin. Listo el Desayuno");
            crono.Stop();
            Console.WriteLine($"Tiempo Transcurrido ASINCRONO =>{crono.ElapsedMilliseconds / 1000} minutos");
        }

        private static async Task DesayunoAsync2()
        {
            // Ejemplo Asincronia con Tareas simultaneas 
            Stopwatch crono = new Stopwatch();
            crono.Start();
            Task<Cafe> prepararCafe = PrepararCafeAsync(); // Es una promise
            Task<Huevo> fritarHuevo = FritarHuevoAsync(2);
            Task<Tocineta> fritarTocineta = FritarTocinetaAsync(3);
            Task<Tostada> fritarTostada = TostarPanAsync(2);

            Cafe posillo = await prepararCafe;
            Console.WriteLine($"\nListo el Cafe en el minuto {crono.ElapsedMilliseconds / 1000} ");
            Huevo huevos = await fritarHuevo;
            Console.WriteLine($"\nListo Los Huevos en el minuto {crono.ElapsedMilliseconds / 1000} ");
            Tocineta tocinetas = await fritarTocineta;
            Console.WriteLine($"\nListo las tocinetas  en el minuto {crono.ElapsedMilliseconds / 1000} ");
            Tostada tostadas = await fritarTostada;
            PonerMantequilla(tostadas);
            PonerMermelada(tostadas);

            Console.WriteLine($"\nListo las tostadas en el minuto {crono.ElapsedMilliseconds / 1000} ");
            Jugo miJugo = PrepararJugo("Guanabana en leche");
            Console.WriteLine($"\nListo el Jugo de {miJugo}");
            Console.WriteLine("\nAl fin. Listo el Desayuno");
            crono.Stop();
            Console.WriteLine($"Tiempo Transcurrido ASINCRONO 2 => {crono.ElapsedMilliseconds / 1000} minutos");
        }

        private static async Task DesayunoAsync3()
        {
            // Ejemplo asincronia con tareas Compuestas 
            Stopwatch crono = new Stopwatch();
            crono.Start();
            Task<Cafe> prepararCafe = PrepararCafeAsync(); // Es una promise
            Task<Huevo> fritarHuevo = FritarHuevoAsync(2);
            Task<Tocineta> fritarTocineta = FritarTocinetaAsync(3);
            Task<Tostada> prepararTostadas = PrepararTostadas(2);

            Cafe posillo = await prepararCafe;
            Console.WriteLine($"\nListo el Cafe en el minuto {crono.ElapsedMilliseconds / 1000} ");
            Huevo huevos = await fritarHuevo;
            Console.WriteLine($"\nListo Los Huevos en el minuto {crono.ElapsedMilliseconds / 1000} ");
            Tocineta tocinetas = await fritarTocineta;
            Console.WriteLine($"\nListo las tocinetas  en el minuto {crono.ElapsedMilliseconds / 1000} ");
            Tostada tostadas = await prepararTostadas;

            Console.WriteLine($"\nListo las tostadas en el minuto {crono.ElapsedMilliseconds / 1000} ");
            Jugo miJugo = PrepararJugo("Guanabana en leche");
            Console.WriteLine($"\nListo el Jugo de {miJugo}");
            Console.WriteLine("\nAl fin. Listo el Desayuno");
            crono.Stop();
            Console.WriteLine($"Tiempo Transcurrido ASINCRONO #3 => {crono.ElapsedMilliseconds / 1000} minutos");
        }

        private static async Task DesayunoAsync4()
        {
            // Ejemplo asincronia manejo de  finalizacion de tareas 
            Stopwatch crono = new Stopwatch();
            crono.Start();
            Task<Cafe> prepararCafe = PrepararCafeAsync(); // Es una promise
            Task<Huevo> fritarHuevo = FritarHuevoAsync(2);
            Task<Tocineta> fritarTocineta = FritarTocinetaAsync(3);
            Task<Tostada> prepararTostadas = PrepararTostadas(2);

            //await Task.WhenAll(prepararCafe, fritarHuevo, fritarTocineta, prepararTostadas);
            var listaTareas = new List<Task> { prepararCafe, fritarHuevo, fritarTocineta, prepararTostadas };
            while (listaTareas.Count > 0)
            {
                Task tareaFinalizada = await Task.WhenAny(listaTareas); //Que tarea fializo de la lista

                if (tareaFinalizada == prepararCafe)
                    Console.WriteLine($"\nListo el Cafe en el minuto {crono.ElapsedMilliseconds / 1000}");
                else if (tareaFinalizada == fritarHuevo)
                    Console.WriteLine($"\nListo Los Huevos en el minuto {crono.ElapsedMilliseconds / 1000}");
                else if (tareaFinalizada == fritarTocineta)
                    Console.WriteLine($"\nListo las tocinetas en el minuto {crono.ElapsedMilliseconds / 1000}");
                else
                    Console.WriteLine($"\nListo las tostadas en el minuto {crono.ElapsedMilliseconds / 1000}");

                listaTareas.Remove(tareaFinalizada);
            }
            //Cafe posillo = await prepararCafe;
            // Console.WriteLine($"\nListo el Cafe ");
            //Huevo huevos = await fritarHuevo;
            // Console.WriteLine($"\nListo Los Huevos ");
            //Tocineta tocinetas = await fritarTocineta;
            // Console.WriteLine($"\nListo las tocinetas ");
            // Tostada tostadas = await prepararTostadas;
            // Console.WriteLine($"\nListo las tostadas  ");
            Jugo miJugo = PrepararJugo("Guanabana en leche");
            Console.WriteLine($"\nListo el Jugo de {miJugo}");
            Console.WriteLine("\nAl fin. Listo el Desayuno");
            crono.Stop();
            Console.WriteLine($"Tiempo Transcurrido ASINCRONO #4 => {crono.ElapsedMilliseconds / 1000} minutos");

        }
        private static Cafe PrepararCafe()
        {
            Console.WriteLine($"Preparando Cafe ");
            Task.Delay(2000).Wait();
            return new Cafe();
        }

        private static async Task<Cafe> PrepararCafeAsync()
        {
            Console.WriteLine($"Preparando Cafe ");
            await Task.Delay(2000);
            return new Cafe();
        }

        private static Huevo FritarHuevo(ushort cant)
        {
            Console.WriteLine($"Calentamos el Sarten .. ");
            Task.Delay(1000).Wait();
            Console.WriteLine($"Fritando {cant}  Huevos");
            Task.Delay(3000).Wait();
            return new Huevo();
        }

        private static async Task<Huevo> FritarHuevoAsync(ushort cant)
        {
            Console.WriteLine($"Calentamos el Sarten .. ");
            await Task.Delay(1000);
            Console.WriteLine($"Fritando {cant}  Huevos");
            await Task.Delay(3000);
            return new Huevo();
        }

        private static Tostada TostarPan(ushort cant)
        {

            for (ushort i = 0; i < cant; i++)
            {
                Console.WriteLine($"Tostando la rebanana # {i} de pan");
                Task.Delay(2000).Wait();

            }

            return new Tostada();
        }

        private static async Task<Tostada> TostarPanAsync(ushort cant)
        {

            for (ushort i = 0; i < cant; i++)
            {
                Console.WriteLine($"Tostando la rebanana # {i} de pan");
                await Task.Delay(2000);
            }

            return new Tostada();
        }

        private static Jugo PrepararJugo(string tipo)
        {
            Console.WriteLine($"Preparando Jugo de {tipo} ");
            Task.Delay(3000).Wait();
            return new Jugo();
        }

        private static Tocineta FritarTocineta(ushort cant)
        {

            for (ushort i = 0; i < cant; i++)
            {
                Console.WriteLine($"TFritando la Tocineta # {i}");
                Task.Delay(2000).Wait();
                time += 2000;
            }

            return new Tocineta();
        }

        private static async Task<Tocineta> FritarTocinetaAsync(ushort cant)
        {

            for (ushort i = 0; i < cant; i++)
            {
                Console.WriteLine($"Fritando la Tocineta # {i}");
                await Task.Delay(2000);
            }

            return new Tocineta();
        }

        private static void PonerMermelada(Tostada tostada) =>
                Console.WriteLine("Poner Mernelada ");

        private static void PonerMantequilla(Tostada tostada) =>
             Console.WriteLine("Poner Mantequilla");

        private static async Task<Tostada> PrepararTostadas(ushort cant)
        {

            Tostada tostadas = await TostarPanAsync(cant);
            PonerMantequilla(tostadas);
            PonerMermelada(tostadas);
            return tostadas;
        }
    }
}