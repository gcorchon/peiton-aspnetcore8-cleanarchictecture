using System.Text;

namespace Peiton.Core.Utils;
public static class NumberExtensions
{
    private static Dictionary<int, string> apocopados = new(){
                 {1,"un"}, {2,"dos"},{3,"tres"}, {4,"cuatro"}, {5,"cinco"}, {6,"seis"}, {7,"siete"}, {8,"ocho"}, {9,"nueve"},
                 {10,"diez"}, {11,"once"}, {12,"doce"},{13,"trece"}, {14,"catorce"}, {15,"quince"}, {16,"dieciséis"}, {17,"diecisiete"},
                 {18,"dieciocho"}, {19,"diecinueve"}, {20,"veinte"}, {21,"veintiún"}, {22,"veintidós"}, {23,"veintitrés"}, {24,"veinticuatro"},
                 {25,"veinticinco"}, {26,"veintiséis"}, {27,"veintisiete"}, {28,"veintiocho"}, {29,"veintinueve"}, {30,"treinta"}, {40,"cuarenta"},
                 {50,"cincuenta"}, {60,"sesenta"},  {70,"setenta"}, {80,"ochenta"}, {90,"noventa"}, {100,"cien"},
                 {200,"doscientos"}, {300,"trescientos"}, {400,"cuatrocientos"}, {500,"quinientos"}, {600,"seiscientos"}, {700,"setecientos"},
                 {800,"ochocientos"}, {900,"novecientos"}};


    private static Dictionary<int, string> sinapocopar = new(){
                 {1,"uno"}, {2,"dos"},{3,"tres"}, {4,"cuatro"}, {5,"cinco"}, {6,"seis"}, {7,"siete"}, {8,"ocho"}, {9,"nueve"},
                 {10,"diez"}, {11,"once"}, {12,"doce"},{13,"trece"}, {14,"catorce"}, {15,"quince"}, {16,"dieciséis"}, {17,"diecisiete"},
                 {18,"dieciocho"}, {19,"diecinueve"}, {20,"veinte"}, {21,"veintiuno"}, {22,"veintidós"}, {23,"veintitrés"}, {24,"veinticuatro"},
                 {25,"veinticinco"}, {26,"veintiséis"}, {27,"veintisiete"}, {28,"veintiocho"}, {29,"veintinueve"}, {30,"treinta"}, {40,"cuarenta"},
                 {50,"cincuenta"}, {60,"sesenta"},  {70,"setenta"}, {80,"ochenta"}, {90,"noventa"}, {100,"cien"},
                 {200,"doscientos"}, {300,"trescientos"}, {400,"cuatrocientos"}, {500,"quinientos"}, {600,"seiscientos"}, {700,"setecientos"},
                 {800,"ochocientos"}, {900,"novecientos"}};

    public static string ToMoneyString(this decimal numero)
    {
        int parteEntera = Math.Abs((int)numero);
        int parteDecimal = Math.Abs(Convert.ToInt32((numero - (int)numero) * 100));

        if (parteDecimal > 0)
            return (numero < 0 ? "menos " : "") + Convertir(parteEntera, true) + (parteEntera != 1 ? " Euros con " : " Euro con ") + Convertir(parteDecimal, true) + " céntimos";
        else
            return (numero < 0 ? "menos " : "") + Convertir(parteEntera, true) + (parteEntera != 1 ? " Euros" : " Euro");
    }

    private static string Convertir(int numero, bool apocopar)
    {
        var numeros = apocopar ? apocopados : sinapocopar;
        if (numeros.ContainsKey(numero)) return numeros[numero];
        if (numero == 0) return "cero";
        int aux = numero;
        var strb = new StringBuilder();
        int terna = 0;
        while (aux > 0)
        {
            terna++;
            int centenas = aux % 1000;
            int decenas = centenas % 100;
            int unidades = decenas % 10;
            string[] partes = new string[3];
            bool listo = false;
            if (numeros.ContainsKey(centenas) && centenas >= 100)
            {
                partes[0] = numeros[centenas];
                listo = true;
            }
            else
            {
                int centena = centenas - decenas;
                if (centena == 100)
                    partes[0] = "ciento";
                else if (centena > 100)
                    partes[0] = numeros[centena];
            }

            if (!listo && decenas >= 10 && numeros.ContainsKey(decenas))
            {
                partes[1] = numeros[decenas];
                listo = true;
            }
            else if (decenas > 10)
            {
                int decena = decenas - unidades;
                partes[1] = numeros[decena] + " y";
            }

            if (!listo && unidades > 0)
                partes[2] = numeros[unidades];

            if (terna == 2)
            {
                if (centenas > 1)
                    strb.Insert(0, Join(" ", partes) + " mil ");
                else
                    strb.Insert(0, "mil ");
            }
            else if (terna == 3)
            {
                if (centenas > 1)
                    strb.Insert(0, Join(" ", partes) + " millones ");
                else
                    strb.Insert(0, "un millón ");
            }
            else if (terna == 1)
            {
                strb.Insert(0, Join(" ", partes));
            }

            aux = aux / 1000;
        }
        return strb.ToString().Trim();
    }

    private static string Join(string separator, string[] partes)
    {
        return string.Join(separator, partes.Where(p => !string.IsNullOrEmpty(p)).ToArray());
    }
}