﻿using ProfilePort.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilePort.Adapters.Interfaces
{
    public interface IMessages
    {
        List<MessageVM> GetMessages(string DashboardId);
        MessageVM GetMessage(int id);
        Message PostNewMessage(MessageVM newMessage, string DashboardId);
        Message deleteMessage(int id);
    }
}
