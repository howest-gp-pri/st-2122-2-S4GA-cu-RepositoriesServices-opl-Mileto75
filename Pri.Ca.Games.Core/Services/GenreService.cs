using Pri.Ca.Games.Core.Entities;
using Pri.Ca.Games.Core.Interfaces.Repositories;
using Pri.Ca.Games.Core.Interfaces.Services;
using Pri.Ca.Games.Core.Services.Models.Games;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<GenreResultModel> GetGenresAsync()
        {
            //perform the checks
            var genres = await _genreRepository.GetGenresAsync();
            GenreResultModel genreResultModel = new GenreResultModel();

            if (genres == null || genres.Count() == 0)
            {
                genreResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No genres found!")
                };
                return genreResultModel;
            }

            genreResultModel.Genres = genres;
            genreResultModel.IsSuccess = true;
            return genreResultModel;
        }
        public async Task<GenreResultModel> GetGenreByIdAsync(int id)
        {
            GenreResultModel genreResultModel = new GenreResultModel();
            //perform checks
            if (id < 1)
            {
                genreResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("Genre not found!")
                };
                genreResultModel.IsSuccess = false;
                return genreResultModel;
            }
            var genre = await _genreRepository.GetGenreByIdAsync(id);
            if(genre == null)
            {
                genreResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("Genre not found!")
                };
                return genreResultModel;
            }
            genreResultModel.Genres = new List<Genre> { genre };
            genreResultModel.IsSuccess = true;
            return genreResultModel;
        }
    }
}


