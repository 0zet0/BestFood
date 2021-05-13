using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BestFood
{
    class Employee
    {
        public Employee() { }
        private Object zakaz;
        private int orderCounter = 1;
        private bool checkBtnPrepare = false, checkOrder = false;
        public Object NewRequest(int quantity, string item)
        {
            if (quantity <= 0)
                throw new Exception("Вы ввели не положительное число!");
            if (orderCounter % 3 == 0)
            {
                if (item == "chicken")
                    item = "egg";
                else
                    item = "chicken";
            }
            checkBtnPrepare = true;
            checkOrder = true;
            orderCounter++;
            if (item == "chicken")
            {
                ChickenOrder chicken = new ChickenOrder(quantity);
                zakaz = chicken;
                return chicken;
            }
            else if (item == "egg")
            {
                EggOrder egg = new EggOrder(quantity);
                zakaz = egg;
                return egg;
            }
            else
            {
                throw new Exception($"I can not cook {item}");
            }
        }
        public Object CopyRequest()
        {
            if (zakaz == null)
                throw new Exception("Нечего копироать");
            checkBtnPrepare = true;
            return zakaz;
        }
        public string Incpect(Object zakaz)
        {
            if (zakaz is EggOrder)
            {
                string messege;
                EggOrder egg = (EggOrder)zakaz;
                messege = "" + egg.GetQuality();
                egg.Crack();
                return "" + messege;
            }
            else return "";
        }
        public string PreparedFood()
        {
            if (!checkOrder)
                throw new Exception("Заказов еще не было!");
            if (!checkBtnPrepare)
                throw new Exception("Заказ уже приготовлена!");
            checkBtnPrepare = false;
            if (zakaz is ChickenOrder)
            {
                ChickenOrder chicken = (ChickenOrder)zakaz;
                for (int i = 0; i < chicken.GetQuantity(); i++)
                {
                    chicken.CutUp();
                }
                chicken.Cook();
                return $"{chicken.GetQuantity()}  штук куриц приготовленo!";
            }
            else if (zakaz is EggOrder)
            {
                EggOrder egg = (EggOrder)zakaz;
                for (int i = 0; i < egg.GetQuantity(); i++)
                {
                    egg.Crack();
                }
                egg.Cook();
                return $"{egg.GetQuantity()}  штук яиц приготовленo!";
            }
            else
            {
                throw new Exception("I can not cook your order!");
            }

        }
        public string Inspect(Object zakaz)
        {
            if (zakaz is ChickenOrder)
                return "";
            else
            {
                EggOrder egg = (EggOrder)zakaz;
                return "" + egg.GetQuality();
            }
        }
    }
}
