using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex
{
    class SimplexMethod
    {
        public int variables;
        public int equation;
        double[,] a;
        List<int> basis;

        public SimplexMethod(double[,] source)
        {
            equation = source.GetLength(0);
            variables = source.GetLength(1);
            a = new double[equation, variables + equation - 1];
            basis = new List<int>();

            for (int i = 0; i < equation; i++)
            {
                for (int j = 0; j < source.GetLength(1); j++)
                {
                    if (j < variables)
                        a[i, j] = source[i, j];
                    else
                        a[i, j] = 0;
                }
                if ((variables + i) < a.GetLength(1))
                {
                    a[i, variables + i] = 1;
                    basis.Add(variables + i);
                }
            }

            variables = a.GetLength(1);

        }
        private bool IsEnd()
        {
            bool flag = true;
            for(int i = 0; i < variables; i++)
            {
                if (a[equation-1,i] < 0)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        public double[,] Counting(double[] result) 
        {
            int maincol , mainrow;
            while (!IsEnd())
            {
                maincol = FindMainCol();
                mainrow = FindMainRow(maincol);
                basis[mainrow] = maincol;

                double[,] newtable = new double[equation, variables];

                for(int i = 0; i < variables; i++)
                {
                    newtable[mainrow, i] = a[mainrow, i] / a[mainrow, maincol];
                }

                for (int i = 0; i < equation; i++)
                {
                    if (i == mainrow)
                        continue;
                    else
                    {
                        for(int j = 0; j < variables; j++)
                        {
                            newtable[i, j] = a[i, j] - a[i, maincol] * newtable[mainrow, j];
                        }
                    }
                }
                a = newtable;
            }
            for (int i = 0; i < result.Length; i++)
            {
                int k = basis.IndexOf(i);
                if (k != -1)
                    result[i] = a[k, (variables-1)/2];
                else
                    result[i] = 0;
            }
            return a;
        }

        private int FindMainCol()
        {
            int mainCol = 1;

            for (int i = 0; i < variables; i++)
            {
                if (a[equation-1,i] < a[equation-1,mainCol])
                {
                    mainCol = i;
                }
            }
            return mainCol;
        }
        private int FindMainRow(int mainCol)
        {
            int MainRow = 0;

            for(int i = 0; i < equation; i++)
            {
                if (a[i, mainCol] > 0)
                {
                    MainRow = i;
                    break;
                }
            }
            for(int i = 0; i < equation; i++)
            {
                if (a[i, mainCol] > 0 && (a[i, (variables-1)/2] / a[i, mainCol]) < (a[MainRow, (variables - 1) / 2] / a[MainRow, mainCol]))
                    MainRow=i;
            }
            return MainRow;
        }
    }
}
