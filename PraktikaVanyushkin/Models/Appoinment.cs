using System;
using Microsoft.VisualBasic;
namespace PraktikaVanyushkin.Models;

public class Appoinment
{
    private int _id;
    private DateTime _appointmentDate;
    private int _doktorID;
    private string _doctorInfo;
    private int _illnessRecord;
    private string _illnessRecordInfo;
    private bool _attendance;

    public Appoinment(int id, DateTime appointmentDate, string doctorInfo, string illnessRecordInfo, bool attendance)
    {
        _id = id;
        _appointmentDate = appointmentDate;
        _doctorInfo = doctorInfo;
        _illnessRecordInfo = illnessRecordInfo;
        _attendance = attendance;
    }

    public int Id => _id;
    public DateTime AppointmentDate => _appointmentDate;
    public int DoctorId => _doktorID;
    public string DoctorInfo => _doctorInfo;
    public string IllnessRecordInfo => _illnessRecordInfo;
    public int IllnessRecord => _illnessRecord;
    public bool Attendance => _attendance;
}