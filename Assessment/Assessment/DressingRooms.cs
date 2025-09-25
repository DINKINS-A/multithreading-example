using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    internal class DressingRooms
    {
        #region Private Fields
        private readonly int m_rooms_available;
        private static SemaphoreSlim m_semaphore;

        #endregion

        #region Constructors

        public DressingRooms() {
            m_rooms_available = 3;
            m_semaphore = new SemaphoreSlim(m_rooms_available, m_rooms_available);
        }

        public DressingRooms(int initial_rooms_available) { 
            m_rooms_available = initial_rooms_available;
            m_semaphore = new SemaphoreSlim(m_rooms_available, m_rooms_available);
        }

        #endregion

        #region Methods
        public static void RequestRoom() {
            m_semaphore.Wait();
        }

        public static void VacateRoom()
        {
            m_semaphore.Release();
        }

        public int GetRoomCount() {
            return m_rooms_available;
        }

        #endregion
    }
}
