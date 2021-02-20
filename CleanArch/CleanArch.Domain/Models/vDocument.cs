using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Models
{
   public class vDocument
    {
        public Guid stream_Id { get; set; }
        public Byte[] file_stream { get; set; }
        public string name { get; set; }       
        public string path_locator { get; set; }
        public string parent_path_locator { get; set; }
        public string file_type { get; set; }
        public Int64? cached_file_size { get; set; }
        public DateTimeOffset creation_time { get; set; }
        public DateTimeOffset last_write_time { get; set; }
        public DateTimeOffset? last_access_time { get; set; }
        public bool is_directory { get; set; }
        public bool is_offline { get; set; }
        public bool is_hidden { get; set; }
        public bool is_readonly { get; set; }
        public bool is_archive { get; set; }
        public bool is_system { get; set; }
        public bool is_temporary { get; set; }
    }
}
