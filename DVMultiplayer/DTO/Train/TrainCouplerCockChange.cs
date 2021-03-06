﻿using DarkRift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVMultiplayer.DTO.Train
{
    public class TrainCouplerCockChange : IDarkRiftSerializable
    {
        public string TrainIdCoupler { get; set; }
        public bool IsCouplerFront { get; set; }
        public bool IsOpen { get; set; }

        public void Deserialize(DeserializeEvent e)
        {
            this.TrainIdCoupler = e.Reader.ReadString();
            this.IsCouplerFront = e.Reader.ReadBoolean();
            this.IsOpen = e.Reader.ReadBoolean();
        }

        public void Serialize(SerializeEvent e)
        {
            e.Writer.Write(TrainIdCoupler);
            e.Writer.Write(IsCouplerFront);
            e.Writer.Write(IsOpen);
        }
    }
}
