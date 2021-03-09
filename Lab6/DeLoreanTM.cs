using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class DeLoreanTM : Car, IFlying  //Класс наследует класс Car и интерфейс IFlying
    {
        public new int Speed    //Свойство на скорость
        {
            get { return speed; }
            set
            {
                if (value < 0 || value > 177) speed = 0;    //DeLorean DMC-12 может разгоняться до 177 км/ч
                else speed = value;
            }
        }
        public DeLoreanTM() : this("Noname", 100) { }  //Конструктор с одним аргументом
        public DeLoreanTM(string name, int speed) : base(name, speed) { } //Конструктор (с тремя аргументами) вызывает базовый с двумя аргументами и заполняет поле цвета
        public override string drive() //Переопределенный метод для езды. При разгоне до 88 миль/ч (или 141 км/ч) машина может путешествовать во времени
        {
            return $"Машина времени DeLorean {name} едет со скоростью {speed} км/ч";
        }
        public string fly() //Переопределенный метод для полета. При разгоне до 88 миль/ч (или 141 км/ч) машина может путешествовать во времени
        {
            return $"Машина времени DeLorean {name} летит со скоростью {speed} км/ч";
        }
        public override string ToString()   //Переопределенный ToString
        {
            return $"Машина времени DeLorean {name}, скорость - {speed} км/ч";
        }
    }
}
