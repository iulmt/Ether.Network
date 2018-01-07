﻿using Ether.Network.Interfaces;
using System;
using System.Net.Sockets;

namespace Ether.Network
{
    /// <summary>
    /// Represents a network connection.
    /// </summary>
    public abstract class NetConnection : INetConnection
    {
        private bool _disposedValue;

        /// <inheritdoc />
        public Guid Id { get; }

        /// <inheritdoc />
        public Socket Socket { get; internal set; }

        /// <summary>
        /// Creates a new <see cref="NetConnection"/> instance.
        /// </summary>
        protected NetConnection()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Disposes the current <see cref="NetConnection"/> resources.
        /// </summary>
        ~NetConnection()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Disposes the current <see cref="NetConnection"/> resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the current <see cref="NetConnection"/> resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (this._disposedValue)
                return;

            if (disposing)
            {
                this.Socket.Dispose();
            }

            this._disposedValue = true;
        }
    }
}
