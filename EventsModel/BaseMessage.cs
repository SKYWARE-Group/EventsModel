using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Lis.EventsModel
{

    //Base class for all messages produced by LIS iLab
    public abstract class BaseMessage
    {

        /// <summary>
        /// Default addres where message should be send
        /// </summary>
        public abstract string DefaultAddress { get; }

        /// <summary>
        /// Id of the message, GUID
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Date and time when message is generated
        /// </summary>
        public DateTime EventTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Origina application neme
        /// </summary>
        public string Application { get; set; }

        /// <summary>
        /// Origina applicaion version
        /// </summary>
        public string ApplicationVersion { get; set; }

        /// <summary>
        /// User Id (ussually username) of the logged in operator
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// If LIS supports location, Id of a location where event is raised
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// Name of the location when event is raised
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// Host name of a computer where message is generated (ussually it's NetBIOS name)
        /// </summary>
        public string HostName { get; set; }


    }

}
