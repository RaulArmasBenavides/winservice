using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsService2RMABcsharp.Debugger
{
  
    public static class Inicio
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MiServicioVirtual());
            }
            catch (Exception ex)
            {
                // LogOCService.LogErrorEx(ex, "Ocurrió un ERROR al iniciar el Servicio (Main)\n");
            }
        }

        //esta clase servirá para depurar
        public class MiServicioVirtual : ApplicationContext
        {
            Thread trdEvento;
            Thread trdEvento2;

            public MiServicioVirtual()
            {
                try
                {
                    CultureInfo cultureperu = new CultureInfo("es-pe", false);
                    cultureperu.NumberFormat.NumberGroupSeparator = ",";
                    cultureperu.NumberFormat.NumberDecimalSeparator = ".";

                    this.trdEvento = new Thread(MonitorearProceso)
                    {
                        Name = "Servicio OC NET",
                        IsBackground = true,
                        CurrentCulture = cultureperu
                    };
                    this.trdEvento.Start();



                    this.trdEvento2 = new Thread(Imprimir);
                    this.trdEvento2.Start();

                }
                catch (Exception ex)
                {
                    throw ex;// LogOCService.LogErrorEx(ex, "Ocurrió un error al iniciar el Servicio(MiServicioVirtual)\n");
                }
            }

            private void MonitorearProceso()
            {
                Debug.Print("Servicio Iniciado exitosamente.");
                while (true)
                {
                    //BoOCService __boOCService = null;
                    try
                    {
                        while (true)
                        {
                            try
                            {
                                try
                                {
                                    //if (__boOCService == null)
                                    //__boOCService = new BoOCService();

                                    //__boOCService.Iniciar();

                                    Thread.Sleep(5000);
                                    Debug.Print("Cargando el método MonitorearProceso");
                                }
                                catch (Exception ex)
                                {
                                    // LogOCService.LogError(ex, "Ocurrió un error al inciar [1].");
                                    //Thread.Sleep(Constantes.TIEMPO_REINICIO_DEFECTO);
                                }
                            }
                            catch (Exception ex)
                            {
                                //  LogOCService.LogError(ex, "Ocurrió un error al inciar [2].");
                                // Thread.Sleep(Constantes.TIEMPO_REINICIO_DEFECTO);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // LogOCService.LogError(ex, "Ocurrió un error al inciar [3].");
                        // Thread.Sleep(Constantes.TIEMPO_REINICIO_DEFECTO);
                    }
                }
            }


            private static CultureInfo GetCulture()
            {
                CultureInfo culturePeru = null;
                try
                {
                    culturePeru = new CultureInfo("es-PE", false);
                    culturePeru.NumberFormat.NumberGroupSeparator = ",";
                    culturePeru.NumberFormat.NumberDecimalSeparator = ".";
                    culturePeru.DateTimeFormat.LongDatePattern = "dd-MM-yyyy hh:mm:ss";
                }
                catch (System.Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
                return culturePeru;
            }

            private void SetCulture()
            {
                CultureInfo culturePeru = new CultureInfo("es-PE", false);
                culturePeru.NumberFormat.NumberGroupSeparator = ",";
                culturePeru.NumberFormat.NumberDecimalSeparator = ".";
                culturePeru.DateTimeFormat.LongDatePattern = "dd-MM-yyyy hh:mm:ss";
                Thread.CurrentThread.CurrentCulture = culturePeru;
                Thread.CurrentThread.CurrentUICulture = culturePeru;
            }



            public static void Imprimir()
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Ejecutando Hilo2");
                    Thread.Sleep(100);
                }

            }
        }
    }
}
