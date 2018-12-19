//namespace ParticleSystem
//{
//    public interface ITweenVector3
//    {
//        Vector3 Lerp(float time, Vector3 v);
//    }

//    public class TweenVector3 : ITweenVector3
//    {
//        private float[] _times; // [0, 1, 2]
//        private Vector3[] _values;

//        public TweenVector3(float[] times, Vector3[] values)
//        {
//            _times = times;
//            _values = values;
//        }

//        public Vector3 Lerp(float time, Vector3 v)
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

//            Vector3 vec3 = _values[i - 1];

//            return Vector3.Lerp(vec3, _values[i], p);
//        }
//    }

//    public class NullTweenVector3 : ITweenVector3
//    {
//        public Vector3 Lerp(float time, Vector3 v)
//        {
//            return v;
//        }
//    }
//}