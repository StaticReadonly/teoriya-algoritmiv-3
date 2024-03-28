using System;
using System.Reflection;

namespace Classes
{
    public class Algorithm
    {
        private long _comparisons = 0L;

        //sort with last pivot
        public long QuickSort1(int[] arr)
        {
            _comparisons = 0L;
            _QuickSort1(arr, 0, arr.Length - 1);
            return _comparisons;
        }

        private void _QuickSort1(int[] arr, int l, int r)
        {
            if (l >= r) return;

            int pivot = _QuickSort1Split(arr, l, r);

            _QuickSort1(arr, l, pivot - 1);
            _QuickSort1(arr, pivot + 1, r);
        }

        private int _QuickSort1Split(int[] arr, int l, int r)
        {
            int pivot = arr[r];
            int index = l - 1;

            for (int i = l; i < r; i++)
            {
                this._comparisons++;
                if (arr[i] < pivot)
                {
                    index++;
                    (arr[index], arr[i]) = (arr[i], arr[index]);
                }
            }

            (arr[r], arr[index + 1]) = (arr[index + 1], arr[r]);
            return index + 1;
        }

        //sort with median of 3
        public long QuickSort2(int[] arr)
        {
            _comparisons = 0L;
            _QuickSort2(arr, 0, arr.Length - 1);
            return _comparisons;
        }

        private void _QuickSort2(int[] arr, int l, int r)
        {
            if (l >= r) return;

            if (r - l == 2)
            {
                _comparisons += 3;
                int m = (l + r) / 2;

                SortThree(arr, l, m, r);

                return;
            }

            if (r - l == 1)
            {
                _comparisons++;
                if (arr[l] > arr[r])
                    (arr[l], arr[r]) = (arr[r], arr[l]);
                return;
            }

            int pivot = _QuickSort2Split(arr, l, r);

            _QuickSort2(arr, l, pivot - 1);
            _QuickSort2(arr, pivot + 1, r);
        }

        private int _QuickSort2Split(int[] arr, int l, int r)
        {
            int m = (l + r) / 2;

            _comparisons += 3;

            SortThree(arr, l, m, r);

            int index = l + 1;
            int pivot = arr[m];
            int pivotIndex = r - 1;
            (arr[m], arr[pivotIndex]) = (arr[pivotIndex], arr[m]);

            for (int i = index; i < pivotIndex; i++)
            {
                _comparisons++;
                if (arr[i] < pivot)
                {
                    (arr[index], arr[i]) = (arr[i], arr[index]);
                    index++;
                }
            }

            (arr[index], arr[pivotIndex]) = (arr[pivotIndex], arr[index]);

            return index;
        }

        //Sort three items at given indices
        private void SortThree(int[] arr, int l, int m, int r)
        {
            int min;
            if (arr[m] < arr[r])
            {
                min = m;
            }
            else
            {
                min = r;
            }

            if (arr[l] > arr[min])
            {
                (arr[l], arr[min]) = (arr[min], arr[l]);
            }

            if (arr[m] > arr[r])
            {
                (arr[m], arr[r]) = (arr[r], arr[m]);
            }
        }

        //sort with 3 pivot elements
        public long QuickSort3(int[] arr)
        {
            _comparisons = 0L;
            _QuickSort3(arr, 0, arr.Length - 1);
            return _comparisons;
        }
        private void _QuickSort3(int[] arr, int l, int r)
        {
            if (l >= r) return;

            int pivot = _QuickSort1Split(arr, l, r);

            _QuickSort3(arr, l, pivot - 1);
            _QuickSort3(arr, pivot + 1, r);
        }

        private int _QuickSort3Split(int[] arr, int l, int r)
        {
            int a = l + 2, b = l + 2, c = r - 1, d = r - 1;
            int p = arr[l], q = arr[l + 1], pivot = arr[r];

            while (b <= c)
            {
                while (arr[b] < q && b <= c)
                {
                    _comparisons++; 
                    if (arr[b] < p)
                    {
                        (arr[a], arr[b]) = (arr[b], arr[a]);
                        a++;
                    }
                    b++;
                }

                while (arr[c] > q && b <= c)
                {
                    _comparisons++; 
                    if (arr[c] > pivot)
                    {
                        (arr[c], arr[d]) = (arr[d], arr[c]);
                        d--;
                    }
                    c--;
                }

                if (b <= c)
                {
                    if (arr[b] > pivot)
                    {
                        _comparisons++; 
                        if (arr[c] < p)
                        {
                            (arr[b], arr[a]) = (arr[a], arr[b]);
                            (arr[a], arr[c]) = (arr[c], arr[a]);
                            a++;
                        }
                        else
                        {
                            (arr[b], arr[c]) = (arr[c], arr[b]);
                        }
                        (arr[c], arr[d]) = (arr[d], arr[c]);
                        b++;
                        c--;
                        d--;
                    }
                    else
                    {
                        _comparisons++; 
                        if (arr[c] < p)
                        {
                            (arr[b], arr[a]) = (arr[a], arr[b]);
                            (arr[a], arr[c]) = (arr[c], arr[a]);
                            a++;
                        }
                        else
                        {
                            (arr[b], arr[c]) = (arr[c], arr[b]);
                        }
                        b++;
                        c--;
                    }
                }
            }

            a--;
            b--;
            c++;
            d++;
            (arr[l + 1], arr[a]) = (arr[a], arr[l + 1]);
            (arr[a], arr[b]) = (arr[b], arr[a]);
            a--;
            (arr[l], arr[a]) = (arr[a], arr[l]);
            (arr[r], arr[d]) = (arr[d], arr[r]);

            return a;
        }

    }
}
