using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Models
{
  //Добавление поиска по жанру
  public class MovieGenreViewModel
  {
    //Список фильмов.
    public List<Movie> Movies { get; set; }
    //Объект SelectList со списком жанров. В этом списке пользователь может выбрать жанр фильма.
    public SelectList Genres { get; set; }
    //Объект MovieGenre, содержащий выбранный жанр.
    public string MovieGenre { get; set; }
    //SearchString, содержащий текст, который пользователи вводят в поле поиска.
    public string SearchString { get; set; }
  }
}
