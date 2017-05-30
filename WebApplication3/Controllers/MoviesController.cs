using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using WebApplication3.Business;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class MoviesController : ODataController
    {
        [EnableQuery]
        public IQueryable<Movie> Get()
        {
            return m_service.Movies.AsQueryable();
        }
        [EnableQuery]
        public SingleResult<Movie> Get([FromODataUri] int key)
        {
            IQueryable<Movie> movie = m_service.Movies.Where(m => m.Id == key).AsQueryable();
            if (movie.Count() == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else
                return SingleResult.Create(movie);
        }

        private DataService m_service = new DataService();
    }
}
