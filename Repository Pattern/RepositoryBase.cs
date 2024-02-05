namespace NET.Design_Patterns.Repository_Pattern
{
    using System;
    using System.Threading.Tasks;
    
    /// Summary:
    ///     This class is used to define the basic contract of a repository.
    /// 
    /// Type parameter:
    ///     T:
    ///         Generic type to base the repository on.
    public abstract class RepositoryBase<T>
    where T : class
    {
        /// Summary:
        ///     A database context object.
        ///
        /// Notes: 
        ///     This object must point to the database context used within the implenting system.
        protected readonly Context context;

        /// Summary:
        ///     A constructor to instantiate the abstract class.
        ///    
        /// Parameters:  
        ///     context:
        ///         A database context object.  
        public RepositoryBase(Context context)
        {
            this.context = context;
        }

        /// Summary:
        ///     A method used to create records.  
        ///    
        /// /// Parameters:
        ///     record:
        ///         A generic object record to create.
        public async Task CreateAsync(T record)
        {
            using (context)
            {
                this.context.Set<T>().Add(record);

                await this.context.SaveChangesAsync();
            }
        }

        /// Summary:
        ///     A method used to get records.   
        /// 
        /// Parameters:
        ///     id:
        ///         The unique identifier of the record to get.
        ///         
        /// Returns:
        ///     A generic object defined when implementing this base class.
        public async Task<T> GetAsync(Guid id)
        {
            using (context)
            {
                return await this.context.Set<T>().FindAsync(id);
            }
        }

        /// Summary:
        ///     A method used to update records.  
        /// 
        /// Parameters:
        ///     record:
        ///         A generic object record to find and update.
        public async Task UpdateAsync(T record)
        {
            using (context)
            {
                this.context.Set<T>().Update(record);

                await this.context.SaveChangesAsync();
            }
        }

        /// Summary:
        ///     A method used to delete records.    
        /// 
        /// Parameters:
        ///     record:
        ///         A generic object record to find and delete.
        public async Task DeleteAsync(T record)
        {
            using (context)
            {
                this.context.Set<T>().Remove(record);

                await this.context.SaveChangesAsync();
            }
        }
    }
}