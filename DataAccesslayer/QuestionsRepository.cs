using DataAccesslayer.AppContext;

namespace DataAccesslayer
{
    internal class QuestionsRepository : IQuestionsRepository
    {
        private readonly DataContext context;

        public QuestionsRepository(DataContext context)
        {
            this.context = context;
        }


    }
}
