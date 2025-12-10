using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFrac
{
    internal class MyFrac
    {
        private long Nom;
        private long DeNom;
        public MyFrac(long nom, long denom)
        {
            if (denom == 0)
                throw new ArgumentException("Denom cannot be zero");
            this.Nom = nom;
            this.DeNom = denom;
            Normalize();
        }
        public MyFrac(MyFrac other)
        {
            Nom = other.Nom;
            DeNom = other.DeNom;
        }
        private void Normalize()
        {
            long gcd = GCD(Nom, DeNom);
            Nom /= gcd;
            DeNom /= gcd;

            if (DeNom < 0)
            {
                Nom = -Nom;
                DeNom = -DeNom;
            }
        }
        private static long GCD(long a, long b)
        {
            while (b != 0)
            {
                (a, b) = (b, a % b);
            }
            return Math.Abs(a);
        }
        public string ToStringWithIntPart()
        {
            long intPart = Nom / DeNom;
            long fracNom = Math.Abs(Nom % DeNom);
            if (Nom < 0 && fracNom == 0)
                return $"-({intPart})+{fracNom}/{DeNom})";
            else if (Nom < 0 && intPart != 0)
            {
                return $"-({Math.Abs(intPart)}+{fracNom}/{DeNom})";
            }
            else
            {
                return $"{intPart}+({fracNom}/{DeNom}";
            }
        }
        public override string ToString() => $"{Nom}/{DeNom}";
        public double ToDouble() => (double)Nom / DeNom;
        public static MyFrac operator +(MyFrac a, MyFrac b) => new MyFrac(a.Nom * b.DeNom + b.Nom * a.DeNom, a.DeNom * b.DeNom);
        public static MyFrac operator -(MyFrac a, MyFrac b) => new MyFrac(a.Nom * b.DeNom - b.Nom * a.DeNom, a.DeNom * b.DeNom);
        public static MyFrac operator *(MyFrac a, MyFrac b) => new MyFrac(a.Nom * b.Nom, a.DeNom * b.DeNom);
        public static MyFrac operator /(MyFrac a, MyFrac b) => new MyFrac(a.Nom * b.DeNom, a.DeNom * b.Nom);
        public static MyFrac CalcExpr1(int n)
        {
            MyFrac res = new MyFrac(0, 1);

            for (int i = 1; i <= n; i++)
            {
                res += new MyFrac(1, i * (i + 1));
            }
            return res;
        }
        public static MyFrac CalcExpr2(int n)
        {
            MyFrac res = new MyFrac(1, 1);

            for (int i = 2; i <= n; i++)
            {
                res *= new MyFrac(1, 1) - new MyFrac(1, i * i);
            }
            return res;
        }
    }
}