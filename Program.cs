namespace Matrix
{
    class Matrix
    {
        public int height;
        public int wight;
        public int[,] matr;

        public Matrix(int h, int w, int[,] m)
        {
            this.height = h;
            this.wight = w;
            this.matr = m;
        }

        public override string ToString()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < wight; j++)
                {
                    Console.Write(matr[i, j] + " ");
                }
                Console.WriteLine();
            }
            return "";
        }

        public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
        {
            int[,] m = new int[firstMatrix.height, secondMatrix.wight];
            Matrix result = new Matrix(firstMatrix.height, firstMatrix.wight, m);
            for (int i = 0; i < firstMatrix.height; i++)
            {
                for (int j = 0; j < firstMatrix.wight; j++)
                {
                    result.matr[i, j] = firstMatrix.matr[i, j] + secondMatrix.matr[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
        {
            int[,] m = new int[firstMatrix.height, secondMatrix.wight];
            Matrix result = new Matrix(firstMatrix.height, firstMatrix.wight, m);
            for (int i = 0; i < firstMatrix.height; i++)
            {
                for (int j = 0; j < firstMatrix.wight; j++)
                {
                    result.matr[i, j] = firstMatrix.matr[i, j] - secondMatrix.matr[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
        {
            int[,] m = new int[firstMatrix.height, secondMatrix.wight];
            Matrix result = new Matrix(firstMatrix.height, secondMatrix.wight, m);
            int num;

            for (int i = 0; i < firstMatrix.height; i++)
            {
                for (int j = 0; j < secondMatrix.wight; j++)
                {
                    num = 0;
                    for (int x = 0; x < firstMatrix.wight; x++)
                    {
                        num += firstMatrix.matr[i, x] * secondMatrix.matr[x, j];
                    }
                    result.matr[i, j] = num;
                }
            }
            return result;
        }

        public int determinant()
        {
            int result = matr[0, 0] * (matr[1, 1] * matr[2, 2] - matr[1, 2] * matr[2, 1])
                - matr[0, 1] * (matr[1, 0] * matr[2, 2] - matr[1, 2] * matr[2, 0])
                + matr[0, 2] * (matr[1, 0] * matr[2, 1] - matr[1, 1] * matr[2, 0]);
            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк первой матрицы");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов первой матрицы");
            int wight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите элементы матрицы");
            int[,] fMatrix = new int[height, wight];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < wight; j++)
                {
                    fMatrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Matrix firstMatrix = new Matrix(height, wight, fMatrix);
            Console.WriteLine(firstMatrix);
            Console.WriteLine("Введите количество строк второй матрицы");
            height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов второй матрицы");
            wight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите элементы матрицы");
            fMatrix = new int[height, wight];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < wight; j++)
                {
                    fMatrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Matrix secondMatrix = new Matrix(height, wight, fMatrix);
            Console.WriteLine(secondMatrix);
            Console.WriteLine("'+' - сложение матриц");
            Console.WriteLine("'-' - вычитание матриц");
            Console.WriteLine("'*' - умножение матриц");
            Console.WriteLine("'determinant' - определители матриц");
            Console.WriteLine("'exit' - завершение программы");
            while (true)
            {
                var sign = Console.ReadLine();
                switch (sign){
                    case "+":
                        if (firstMatrix.height != secondMatrix.height || firstMatrix.wight != secondMatrix.wight)
                        {
                            Console.WriteLine("Матрицы невозможно сложить");
                        }
                        else
                        {
                            Console.WriteLine(firstMatrix + secondMatrix);
                        }
                        break;
                    case "-":
                        if (firstMatrix.height != secondMatrix.height || firstMatrix.wight != secondMatrix.wight)
                        {
                            Console.WriteLine("Матрицы невозможно вычесть");
                        }
                        else
                        {
                            Console.WriteLine(firstMatrix - secondMatrix);
                        }
                        break;
                    case "*":
                        if (firstMatrix.wight == secondMatrix.height)
                        {
                            Console.WriteLine(firstMatrix * secondMatrix);
                        }
                        else
                        {
                            Console.WriteLine("Матрицы невозможно перемножить");
                        }
                        break;
                    case "determinant":
                        if (firstMatrix.height == 3 && firstMatrix.wight == 3)
                        {
                            Console.WriteLine("Определитель для первой матрицы: " + firstMatrix.determinant());
                        }
                        else
                        {
                            Console.WriteLine("Определитель для первой матрицы: Матрица не являются тринарной");
                        }
                        if (secondMatrix.height == 3 && secondMatrix.wight == 3)
                        {
                            Console.WriteLine("Определитель для второй матрицы: " + secondMatrix.determinant());
                        }
                        else
                        {
                            Console.WriteLine("Определитель для второй матрицы: Матрица не являются тринарной");
                        }
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("'" + sign + "' не является командой, исполняемой программой");
                        break;
                }
            }

        }
    }
}