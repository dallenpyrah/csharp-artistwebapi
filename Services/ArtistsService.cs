using System;
using System.Collections.Generic;
using artists.Models;
using artists.Repository;

namespace artists.Services
{
    public class ArtistsService
    {
        private readonly ArtistsRepository _repo;

        public ArtistsService(ArtistsRepository repo)
        {
            _repo = repo;
        }

        internal object CreateArtist(Artist newArtist)
        {
            return _repo.CreateArtist(newArtist);
        }

        internal IEnumerable<Artist> GetAllArtists()
        {
            return _repo.GetAllArtists();
        }

        internal Artist GetArtistById(int id)
        {
            return _repo.GetArtistById(id);
        }

        internal Artist EditArtist(Artist editedArtist)
        {
            Artist currentArtist = GetArtistById(editedArtist.Id);
            if (currentArtist == null)
            {
                throw new SystemException("INVALID ID");
            }
            else
            {
                currentArtist.Name = editedArtist.Name != null ? editedArtist.Name : currentArtist.Name;
                currentArtist.Age = editedArtist.Age > 0 ? editedArtist.Age : currentArtist.Age;
                currentArtist.Instrument = editedArtist.Instrument != null ? editedArtist.Instrument : currentArtist.Instrument;
                currentArtist.Location = editedArtist.Location != null ? editedArtist.Location : currentArtist.Location;
                return _repo.EditArtist(editedArtist);
            }
        }

        internal Artist DeleteArtist(int id)
        {
            Artist currentArtist = GetArtistById(id);
            if (currentArtist == null)
            {
                throw new SystemException("INVALID ID");
            }
            else
            {
                _repo.DeleteArtist(id);
                return currentArtist;
            }
        }
    }
}