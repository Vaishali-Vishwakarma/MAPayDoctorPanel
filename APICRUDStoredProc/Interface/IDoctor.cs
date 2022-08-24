using APICRUDStoredProc.Models;

namespace APICRUDStoredProc.Interface
{
    public interface IDoctor
    {
        public List<Doctor> GetDoctorDetails();

        public void AddDoctor(Doctor doctor);

        public void UpdateDoctorDetails(Doctor doctor);

        public Doctor GetDoctorData(int id);

        public void DeleteDoctor(int id);
    }
}
