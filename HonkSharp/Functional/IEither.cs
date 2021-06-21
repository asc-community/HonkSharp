namespace HonkSharp.Functional
{
    public interface IEither
    {
        public Either<T, Failure> As<T>();
        
        public bool Is<T>(out T res);
        
        
        /// <summary>
        /// Upcasts the current value of
        /// an either instance to object.
        /// </summary>
        public object? ToObject();
    }
}