﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTKTT_Buoi2_DangNguyenCongHau
{
    class Program
    {

        public static void Main()
        {
            Console.InputEncoding = UnicodeEncoding.Unicode;
            Console.OutputEncoding = UnicodeEncoding.Unicode;

            Console.WriteLine("Chọn bài toán:");
            Console.WriteLine("1. Tìm kiếm nhị phân.");
            Console.WriteLine("2. Sắp xếp MergeSort.");
            Console.WriteLine("3. Tìm kiếm nhị phân không sử dụng đẹ qui.");
            Console.WriteLine("4. Tinhs toongr cac phan tu trong mang khong su dung.");
            Console.WriteLine("5. tinh tong phan tu trong mang co su dung de qui.");



            Console.WriteLine("Chọn 1 số đi brooo.");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    int[] arr = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
                    int n = arr.Length;
                    int x = 30;

                    int result = binarySearch(arr, 0, n - 1, x);

                    if (result == -1)
                        Console.WriteLine("Không tìm thấy");
                    else
                        Console.WriteLine("Giá trị ở vị trí " + result);
                    Console.ReadKey();

                    break;
                case 2:
                    do
                    {
                        Console.Write("\nNhap vao so luong phan tu cua mang: ");
                        n = int.Parse(Console.ReadLine());
                    } while (n <= 0);
                    int[] intArray = new int[n];
                    Console.WriteLine("Nhap vao cac phan tu cua mang: ");
                    for (int i = 0; i < intArray.Length; i++)
                    {
                        intArray[i] = int.Parse(Console.ReadLine());
                    }
                    SortMethod(intArray, 0, n - 1);
                    Console.Write("Cac phan tu sau khi sap xep: ");
                    foreach (int item in intArray)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();

                    Console.ReadLine();
                    break;
                case 3:
                    int[] arr3 = { 2, 3, 4, 10, 40 };
                    int x3 = 10;
                    int result3 = BinarySearchNonR(arr3, x3);

                    if (result3 != -1)
                        Console.WriteLine("Phần tử được tìm thấy tại chỉ số " + result3);
                    else
                        Console.WriteLine("Phần tử không có trong mảng");
                    Console.ReadKey();

                    break;

                case 4:
                    int[] a = new int[100];
                    int i1, n1, sum = 0;

                    Console.Write("Nhap so phan tu can luu tru vao trong mang: ");
                    n1 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Nhap {0} phan tu vao trong mang: \n", n1);
                    for (i1 = 0; i1 < n1; i1++)
                    {
                        Console.Write("Phan tu - {0}: ", i1);
                        a[i1] = Convert.ToInt32(Console.ReadLine());
                    }

                    for (i1 = 0; i1 < n1; i1++)
                    {
                        sum += a[i1];
                    }

                    Console.Write("Tong cac phan tu trong mang la: {0}\n\n", sum);      

                    Console.ReadKey();
                
                    break;
                case 5:
                    int[] array = { 1, 2, 3, 4, 5,6 };
                    int sum1 = SumArray(array, array.Length);
                    Console.WriteLine("Tổng các phần tử trong mảng là: " + sum1);
                    Console.ReadKey();

                    break;
                case 6:
                    int[] arr2 = { 10, 7, 8, 9, 1, 5 };
                    int n2 = arr2.Length;
                    Console.WriteLine("Mảng ban đầu:");
                    PrintArray(arr2);

                    QuickSort(arr2, 0, n2 - 1);

                    Console.WriteLine("Mảng sau khi sắp xếp:");
                    PrintArray(arr2);
                    Console.ReadKey();

                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;

            }
        }
        // tinh tong cac phan tu trong mang de qui
        static int SumArray(int[] array, int length)
        {
            if (length <= 0)
                return 0;
            return array[length - 1] + SumArray(array, length - 1);
        }
        //tim kiem nhi phan de qui
        static int binarySearch(int[] arr, int left,
                            int right, int x)
        {
            if (right >= left)
            {
                int mid = left + (right - left) / 2;


                if (arr[mid] == x)
                    return mid;

                if (arr[mid] > x)
                    return binarySearch(arr, left, mid - 1, x);

                return binarySearch(arr, mid + 1, right, x);
            }

            return -1;
        }
        //merge sort
        static public void MergeMethod(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);
            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }
            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];
            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];
            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
        static public void SortMethod(int[] numbers, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                SortMethod(numbers, left, mid);
                SortMethod(numbers, (mid + 1), right);
                MergeMethod(numbers, left, (mid + 1), right);
            }
        }
        //tim kiem nhi phan khong de qui
        static int BinarySearchNonR(int[] arr, int x)
        {
            int left = 0, right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == x)
                    return mid;

                if (arr[mid] < x)
                    left = mid + 1;

                else
                    right = mid - 1;
            }

            return -1;
        }

        // Hàm chính của Quick Sort
        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        // Hàm chia mảng và tìm phần tử phân chia
        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];  
            int i = (low - 1);  

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;

                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;

                    Console.WriteLine("Hoán đổi {0} và {1}", arr[i], arr[j]);
                    PrintArray(arr);
                }
            }

            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            Console.WriteLine("Hoán đổi {0} và {1}", arr[i + 1], arr[high]);
            PrintArray(arr);

            return i + 1;  
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

    }   
}

    
