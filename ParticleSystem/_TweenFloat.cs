//namespace ParticleSystem
//{
//    public interface ITweenFloat
//    {
//        float Lerp(float time, float f);
//    }

//    public class TweenFloat : ITweenFloat
//    {
//        private float[] _times; // [0, 1, 2]
//        private float[] _values; // [1, 20, 50]

//        public TweenFloat(float[] times, float[] values)
//        {
//            _times = times;
//            _values = values;
//        }

//        public float Lerp(float time, float f)
//        {
//            int i = 0;
//            int n = _times.Length;

//            while (i < n && time > _times[i])
//            {
//                i++;
//            }

//            if (i == 0) return _values[0]; // first
//            if (i == n) return _values[n - 1]; // last

//            float p = (time - _times[i - 1]) / (_times[i] - _times[i - 1]);

//            return _values[i - 1] + p * (_values[i] - _values[i - 1]);
//        }
//    }

//    public class NullTweenFloat : ITweenFloat
//    {
//        public float Lerp(float time, float f)
//        {
//            return f;
//        }
//    }
//}