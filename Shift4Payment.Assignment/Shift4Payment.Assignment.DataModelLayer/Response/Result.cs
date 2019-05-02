
namespace Shift4Payment.Assignment.DataModelLayer.Response
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> 
    {
        /// <summary>
        /// true if successful
        /// </summary>
        public bool Success { get; set; }
        
        /// <summary>
        /// Exception message if any
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// holds the result
        /// </summary>
        public T Model { get; set; }

    }
}
