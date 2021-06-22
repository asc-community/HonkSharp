namespace HonkSharp.Functional
{
    /// <summary>
    /// This interface unites all Either types
    /// </summary>
    public interface IEither
    {
        /// <summary>
        /// Casts an either to T. Returns
        /// a failure if cannot cast
        /// </summary>
        public Either<T, Failure> As<T>();
        
        /// <summary>
        /// Checks if either has the type of T.
        /// If it is not, the value of res
        /// is undefined.
        /// </summary>
        public bool Is<T>(out T res);
        
        
        /// <summary>
        /// Upcasts the current value of
        /// an either instance to object.
        /// </summary>
        public object? ToObject();
    }
}