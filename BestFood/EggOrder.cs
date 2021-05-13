using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BestFood
{
    class EggOrder
    {

        private static Random rnd = new Random();
        private int quantity;
        private int quality = rnd.Next(101);
        private static int qualityCounter = 0;
        public EggOrder(int quantity)
        {
            this.quantity = quantity;
            qualityCounter++;
        }
        public int GetQuantity()
        {
            return quantity;
        }
        public int? GetQuality()
        {

            if (qualityCounter % 2 == 1)
            {
                return quality;
            }
            else
            {
                return null;
            }
        }
        public void Crack()
        {
            if (GetQuality() < 25)
                throw new Exception($"Качество: {GetQuality()}, яйцо испорчено!");
        }
        public void DiscardShell()
        {
            //TODO
        }
        public void Cook()
        {
            //TODO
        }
    }
}
