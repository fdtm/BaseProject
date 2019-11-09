using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Core.Services.Communications
{
    public class Response<TEntity> : BaseResponse where TEntity : class
    {
        public TEntity Entity { get; set; }

        private Response(bool success, string message, TEntity entity) : base(success, message)
        {
            entity = Entity;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="entity">Saved entity.</param>
        /// <returns>Response.</returns>
        public Response(TEntity entity) : this(true, string.Empty, entity)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public Response(string message) : this(false, message, null)
        { }
    }
}
