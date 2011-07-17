using System;
using Microsoft.SPOT;

namespace Bot
{
    public interface iController
    {
        void wake();
        void update();
        void sleep();
    }

}
