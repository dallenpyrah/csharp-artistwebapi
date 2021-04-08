using System;
using System.Collections.Generic;
using System.Data;
using artists.Models;
using Dapper;

namespace artists.Repository
{
    public class ArtistsRepository
    {
        public readonly IDbConnection _db;

        public ArtistsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Artist CreateArtist(Artist newArtist)
        {
            string sql = @"
            INSERT INTO artists
            (name, age, instrument, location)
            VALUES
            (@Name, @Age, @Instrument, @Location);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newArtist);
            newArtist.Id = id;
            return newArtist;
        }

        internal Artist GetArtistById(int id)
        {
            string sql = "SELECT * FROM artists WHERE id = @id;";
            return _db.QueryFirstOrDefault<Artist>(sql, new { id });
        }

        internal IEnumerable<Artist> GetAllArtists()
        {
            string sql = "SELECT * FROM artists;";
            return _db.Query<Artist>(sql);
        }

        internal Artist EditArtist(Artist editedArtist)
        {
            string sql = @"
            UPDATE artists
            SET
            name = @Name,
            location = @Location,
            age = @Age,
            instrument = @Instrument
            WHERE id = @id;
            SELECT * FROM artists WHERE id = @id;";
            _db.QueryFirstOrDefault<Artist>(sql, editedArtist);
            return editedArtist;
        }

        internal void DeleteArtist(int id)
        {
            string sql = "DELETE FROM artists WHERE id = @id LIMIT 1;";
            _db.ExecuteScalar<Artist>(sql, new { id });
            return;
        }
    }
}