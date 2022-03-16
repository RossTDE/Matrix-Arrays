// - - - - - - - - - - ZADACHA 1 - - - - - - - - - -
//Объявить одномерный (5 элементов) массив с именем A и двумерный массив (3 строки, 4 столбца) дробных чисел с именем B.
//Заполнить одномерный массив
//А числами, введенными с клавиатуры пользователем, а
//двумерный массив В случайными числами с помощью
//циклов. Вывести на экран значения массивов: массива
//А в одну строку, массива В — в виде матрицы. Найти в
//данных массивах общий максимальный элемент, минимальный элемент, общую сумму всех элементов, общее
//произведение всех элементов, сумму четных элементов
//массива А, сумму нечетных столбцов массива В.

Random rand = new Random();
int[] A = new int[] {1,2,3,4,5}; //5 по условию задачи
int[,] B = new int[3,4]; //3, 4 по условию задачи. Пока инт для проверки,
                         //потом поменяю на дабл и добавлю округление
int min1 = 0, max1 = 0;

for (int i = 0; i < 5; i++) //заполение обоих массивов
{
    if(i < 4)
    {
        for(int j = 0; j < 3; j++)
        {
            B[j,i] = rand.Next(1, 10);
        }
    }
   // A[i] = Convert.ToInt32(Console.ReadLine());
}

for (int i = 0;i < 3;i++) //красивая печать
{
    for (int j = 0;j < 4;j++)
    {
        Console.Write(B[i,j] + " ");
    } Console.WriteLine();
}

for (int i = 0; i < 5; i++) //поиск минимума м максимума
{
    for(int j = 0; j < 3; j++)
    { 
        for (int f = 0; f < 4; f++)
        {
            if (A[i] == B[j, f])
            {
                if (min1 == 0 && max1 == 0) min1 = max1 = A[i];
                else if (A[i] > max1) max1 = A[i];
                else if (A[i] < min1) min1 = A[i];
            }
        }
    }
}
Console.WriteLine("Min: {0}, Max: {1}", min1, max1);
Console.WriteLine();
// - - - - - - - - - - ZADACHA 2 - - - - - - - - - -
//Дан двумерный массив размерностью 5×5, заполненный случайными числами из диапазона от –100 до 100.
//Определить сумму элементов массива, расположенных
//между минимальным и максимальным элементами.

int min = 100, max = -100; //тк в условии написано от -100 до 100, использую для
                           //того, чтоб избежать еще 2 циклов
int[] indexes = new int[] { 0, 0, 0, 0 }; //для фиксирования индексов {y1,x1,y2,x2}
                                       //по умолчанию 0,0,0,0

int[,] arr = new int[5, 5]; //5 по условию задачи
long sum = 0;

for(int i = 0; i < 5; ++i) //находим минимум и максимум и запоминаем индексы
{
    for(int j = 0; j < 5; ++j)
    {
        arr[i,j] = rand.Next(-100, 101); //тк рандом берет до второго -1
        if (arr[i, j] > max)
        {
            max = arr[i, j];
            indexes[0] = i; 
            indexes[1] = j;
        }
        if(arr[i,j] < min)
        {
            min = arr[i,j];
            indexes[2] = i;
            indexes[3] = j;
        }
    }
}

if(indexes[0] > indexes[2]) //делаем так, чтоб шло от меньшего к большему
{
    int tmp = indexes[0];
    indexes[0] = indexes[2];
    indexes[2] = tmp;
    tmp = indexes[1];
    indexes[1] = indexes[3];
    indexes[3] = tmp;
}

for (int i = 0; i < 5; i++) //печать
{
    for (int j = 0; j < 5; j++)
    {
        Console.Write(arr[i, j] + " ");
    }
    Console.WriteLine();
}


for (int i = indexes[0]; i <= indexes[2]; ++i) //бежим по массиву и суммируем все
{
    if(i == indexes[0])
    {
        for (int j = indexes[1]; j < 5; ++j)
        {
            sum += arr[i, j];
            //Console.Write(arr[i, j] + " ");
        }
    } else if(i == indexes[2])
    {
        for (int j = 0; j <= indexes[3]; ++j)
        {
            sum += arr[i, j];
            //Console.Write(arr[i, j] + " ");
        }
    } else
    {
        for (int j = 0; j < 5; ++j)
        {
            sum += arr[i,j];
            //Console.Write(arr[i, j] + " ");
        }
    } 
}

Console.WriteLine("Min: {0} Max: {1} Sum: {2}", min, max, sum); //печатаем и радуемся
Console.WriteLine();
// - - - - - - - - - - ZADACHA 3 - - - - - - - - - -
//Пользователь вводит строку с клавиатуры. Необходимо зашифровать данную строку используя шифр Цезаря.

string text;
Console.Write("Enter your text: ");
text = Console.ReadLine();
Console.Write("If you want to encrypt press 1, if you want to decrypt press 2: ");

ConsoleKeyInfo info = Console.ReadKey(); 
char key = info.KeyChar;

int gap;
Console.Write("\nEnter gap: ");
gap = Convert.ToInt32(Console.ReadLine());

string new_text = "";
if(key == '1') //зашифровка
{
    for(int i = 0; i < text.Length; ++i)
    {
        if(text[i] >= 'a' && text[i] <= 'z')
        {
            new_text += (char)((text[i] + gap - 'a') % 26 + 'a'); //сам придумав :>
        } else if (text[i] >= 'A' && text[i] <= 'Z')
        {
            new_text += (char)((text[i] + gap - 'A') % 26 + 'A');
        } else
        {
            new_text += text[i];
        }
    }
} else if(key == '2') //расшифровка
{
    for (int i = 0; i < text.Length; ++i)
    {
        if (text[i] >= 'a' && text[i] <= 'z')
        {
            new_text += (char)('z' - ('z' - (text[i] - gap))%26); //сам придумав :>
        }
        else if (text[i] >= 'A' && text[i] <= 'Z')
        {
            new_text += (char)('Z' - ('Z' - (text[i] - gap)) % 26);
        }
        else
        {
            new_text += text[i];
        }
    }
}
Console.WriteLine("Your new text: " + new_text + '\n');

// - - - - - - - - - - ZADACHA 4 - - - - - - - - - -
//Создайте приложение, которое производит операции над матрицами

int[,] x = new int[3,3] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } }; //просто для примера
int[,] y = new int[3,3] { { 2, 3, 4 }, { 2, 3, 4 }, { 2, 3, 4 } };

Console.WriteLine("Array x * 5: "); //умножаем массив на 5, тоже для примера, так то можно на все что угодно
for (int i = 0; i < 3; i++) 
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write(x[i, j]*5 + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("Array x * y: "); //перемножаем, вроде так, если я правильно понял как умножаются матрицы
for (int i = 0; i < 3; i++) 
{
    for (int j = 0; j < 3; j++)
    {
        int tmp = 0; //временая переменная для хранения суммы произведения столбцов
        for (int k = 0; k < 3; k++)
        {
            tmp += x[j,k]*y[j,i];
        }
        Console.Write(tmp + " "); //так как при умножении матриц новые значения записываются по очереди в столбик, а не в строчку,
                                  //выведенный массив будет перевернут на 90 градусов, при создании нового массива нужно
                                  //было бы заполнять так: new_arr[j,i] = tmp
    }
    Console.WriteLine();
}

Console.WriteLine("Array x + y: "); //сложение
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write(x[i, j] + y[i, j] + " "); //как я понял они просто складываются
    }
    Console.WriteLine();
}
