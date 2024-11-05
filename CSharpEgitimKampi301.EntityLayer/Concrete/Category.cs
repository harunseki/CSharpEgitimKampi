using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get ; set; }
        public bool CategoryStatus { get; set; }
    }
}


/*
 Field-Property-Variable
 */

/*
 int x; -> Field (bir değişken direkt olarak classın içinde tanımlanması)
 public int y {get; set;} -> Property (değişkenin bir classın içinde get ve set ile tanımlanması)
 void test { 
    int z; -> Variable(değişken) (metodun içinde tanımlanırsa )
 }
 */