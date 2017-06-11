using Artists.Controllers;
using Artists.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Artists.Core.ViewModels
{
    public class GigFormViewModel
    {
        public  int Id { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime() {
            
            return DateTime.Parse(string.Format("{0} {1}", Date, Time), CultureInfo.CurrentCulture, DateTimeStyles.None);
        }

        public string Heading { get; set; }
        public string Action {
            get {


                /*
                primer parametro de Func es parametro de entrada, el segundo es el tipo de retorno
                no estamos llamando al metodo solo creando una expresion
                */
                Expression<Func<GigsController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<GigsController, ActionResult>> create = (c => c.Create(this));
                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;

            }
        }



    }
}
