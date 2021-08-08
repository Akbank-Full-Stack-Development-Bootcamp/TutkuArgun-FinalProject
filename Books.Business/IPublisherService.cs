using Books.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business
{
    public interface IPublisherService
    {
        IList<PublisherListResponse> GetAllPublishers();
        PublisherListResponse GetPublisherById(int id);
        int AddPublisher(AddNewPublisherRequest request);
        int UpdatePublisher(EditPublisherRequest request);
        void DeletePublisher(int id);
    }
}
