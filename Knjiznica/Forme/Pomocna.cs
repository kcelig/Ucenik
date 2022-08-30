using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knjiznica.Forme
{
    public class Pomocna
    {
        public static void PrikaziListuUListBoxu<T> (
            List<T> lista,
            System.Windows.Forms.ListBox lb ) {

                lb.Items.Clear();
                lista.Sort();
                foreach (T element in lista) {
                    lb.Items.Add(element);
                }

        }

    }
}
