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

            for(int i = l; i < r; i++)
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

            int pivot = _QuickSort2Split(arr, l, r);

            _QuickSort2(arr, l, pivot - 1);
            _QuickSort2(arr, pivot + 1, r);
        }

        private int _QuickSort2Split(int[] arr, int l, int r)
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
    }
}
