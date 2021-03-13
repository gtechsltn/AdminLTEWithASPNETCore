﻿using PSC.Domain.CommonTables;
using PSC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Providers.CommonTables
{
    public class AzureLocationProvider
    {
        /// <summary>
        /// The database
        /// </summary>
        private PSCContext _db;

        public AzureLocationProvider(PSCContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<AzureLocation> CreateIfNotExist(string name)
        {
            long id = GetIdByNameAsync(name);

            if (id == 0)
                id = await InsertAsync(new AzureLocation() { Name = name });

            return await GetAsync(id);
        }

        public IEnumerable<AzureLocation> GetValues()
        {
            return _db.AzureLocations;
        }

        public async Task<AzureLocation> GetAsync(long id)
        {
            return await _db.AzureLocations.FindAsync(id);
        }

        public long GetIdByNameAsync(string name)
        {
            return _db.AzureLocations.Where(r => r.Name.ToLower() == name.ToLower())?.FirstOrDefault()?.ID ?? 0;
        }

        public async Task<long> InsertAsync(AzureLocation value)
        {
            await _db.AddAsync(value);
            await _db.SaveChangesAsync();
            return value.ID;
        }

        public async Task ReplaceAsync(int id, AzureLocation value)
        {
            _db.Update(value);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _db.AzureLocations.FindAsync(id);
            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<long> DeleteMultipleAsync(long[] ids)
        {
            long c = 0;
            foreach (long id in ids)
            {
                c += await DeleteAsync(id) ? 1 : 0;
            }
            return c;
        }
    }
}
