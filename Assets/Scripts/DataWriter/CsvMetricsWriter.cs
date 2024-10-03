using System.IO;
using Core;
using UnityEngine;
using Vehicle;

namespace DataWriter
{
    public class CsvMetricsWriter : MonoBehaviour
    {
        private StreamWriter _writer;

        private const string Path = "Files/";
        private const string Filename = "Save.csv";
        private const string DataLabel = "Speed, Rotations, Status, Gear position, TransmissionMode, Proximity";

        private void Start()
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }

            _writer = new StreamWriter(Path + Filename);

            _writer.WriteLine(DataLabel);
            _writer.Flush();
        }

        private void FixedUpdate()
        {
            if (!PlayerCarMetricsProvider.PlayerVehicleMetrics)
            {
                Debug.LogError("Player metrics is null!");
                return;
            }

            VehicleMetrics metrics = PlayerCarMetricsProvider.PlayerVehicleMetrics;

            string newDataLine = string.Format("{0:0}, {1}, {2}, {3}, {4}, {5:0.0}",
                metrics.Velocity,
                metrics.EngineRotations,
                metrics.EngineStatus,
                metrics.ActiveGearPosition,
                metrics.TransmissionOperatingMode,
                metrics.DistanceToTheCar);
            
            _writer.WriteLine(newDataLine);
            _writer.Flush();
        }
    }
}