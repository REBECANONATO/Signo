using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuSigno
{
    class Program
    {
        static void Main(string[] args)
        {

            InterpretadorSigno interpretador = new InterpretadorSigno();
            Signo signo = null;
            string diaNasc;
            string mesNasc;
            int diaNascInt = 0;
            int mesNascInt = 0;

            do
            {
                mesNasc = null;
                diaNasc = null;
                Write("\n\n\tQual Mês você Nasceu: ");
                mesNasc = ReadLine();

                mesNascInt = ValidaDadosMes(mesNasc);

                if (mesNascInt != 9999)
                {
                    Write("\n\tQual Dia você Nasceu: ");
                    diaNasc = ReadLine();

                    diaNascInt = ValidaDadosDia(diaNasc, mesNascInt);
                }

            } while (mesNascInt == 9999 || diaNascInt == 9999);

            signo = interpretador.Interpretar(diaNascInt, mesNascInt);

            if(signo == null)
            {
                WriteLine("\n\n\t Não foi possível interpretar seu signo");
                ReadLine();
            }
            else
            {
                WriteLine("\n\n\t" + signo.nome + ": " + signo.caracteristicas);
                ReadLine();
            }


        }

        private static int ValidaDadosMes(string data)
        {
            int mesInt = 0;

            mesInt = ValidaDados(data);

            if (mesInt < 1 || mesInt > 12)
            {
                Clear();
                WriteLine("\n\n\tO Mês deve estar entre 1 e 12");
                ReadLine();
                return 9999;
            }

            return mesInt;
        }

        private static int ValidaDadosDia(string data, int mes)
        {
            int diaInt = 0;

            diaInt = ValidaDados(data);

            if ((diaInt < 1 || diaInt > 31) && (mes == 1 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12))
            {

                Clear();
                WriteLine("\n\n\tPara este mês considere dias de 1 a 31");
                ReadLine();
                return 9999;
            }
            else
            {
                if ((diaInt < 1 || diaInt > 30) && (mes == 4 || mes == 6 || mes == 9 || mes == 11))
                {

                    Clear();
                    WriteLine("\n\n\tPara este mês considere dias de 1 a 30");
                    ReadLine();
                    return 9999;
                }
                else
                {
                    if(diaInt < 1 || diaInt > 28)
                    {
                        Clear();
                        WriteLine("\n\n\tPara este mês considere dias de 1 a 28");
                        ReadLine();
                        return 9999;
                    }
                }
            }

            return diaInt;
        }

        private static int ValidaDados(string data)
        {
            int dataInt = 0;

            if (!int.TryParse(data, out dataInt))
            {
                Clear();
                WriteLine("\n\n\tFavor digitar o Dia e o Mês Númerico.");
                ReadLine();
                return 9999;
            }
            return dataInt;
        }
    }
}
