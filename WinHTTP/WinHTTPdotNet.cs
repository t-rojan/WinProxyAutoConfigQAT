using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace WinHTTPdotNet
{

    /// <summary>
    /// Provides vanilla access to the native winhttp.dll API
    /// </summary>
    public class WinHTTPdotNet
    {


        public enum InternetDefaultPort
        {
            [Description("INTERNET_DEFAULT_PORT")]
            INTERNET_DEFAULT_PORT = 0,
            [Description("INTERNET_DEFAULT_HTTP_PORT")]
            INTERNET_DEFAULT_HTTP_PORT = 80,
            [Description("INTERNET_DEFAULT_HTTPS_PORT")]
            INTERNET_DEFAULT_HTTPS_PORT = 443
        };
        public enum AccessType
        {
            [Description("WINHTTP_ACCESS_TYPE_DEFAULT_PROXY")]
            WINHTTP_ACCESS_TYPE_DEFAULT_PROXY = 0,
            [Description("WINHTTP_ACCESS_TYPE_NO_PROXY")]
            WINHTTP_ACCESS_TYPE_NO_PROXY = 1,
            [Description("WINHTTP_ACCESS_TYPE_NAMED_PROXY")]
            WINHTTP_ACCESS_TYPE_NAMED_PROXY = 3,
            [Description("WINHTTP_ACCESS_TYPE_AUTOMATIC_PROXY")]
            WINHTTP_ACCESS_TYPE_AUTOMATIC_PROXY = 4
        }
        public enum OpenFlags
        {
            [Description("WINHTTP_FLAG_NONE")]
            WINHTTP_FLAG_NONE = 0x00000000,
            [Description("WINHTTP_FLAG_ASYNC")]
            WINHTTP_FLAG_ASYNC = 0x10000000,

        }
        public enum OpenRequestFlags
        {
            [Description("WINHTTP_FLAG_SECURE")]
            WINHTTP_FLAG_SECURE = 0x00800000,
            [Description("WINHTTP_FLAG_ESCAPE_PERCENT")]
            WINHTTP_FLAG_ESCAPE_PERCENT = 0x00000004,
            [Description("WINHTTP_FLAG_NULL_CODEPAGE")]
            WINHTTP_FLAG_NULL_CODEPAGE = 0x00000008,
            [Description("WINHTTP_FLAG_BYPASS_PROXY_CACHE")]
            WINHTTP_FLAG_BYPASS_PROXY_CACHE = 0x00000100,
            [Description("WINHTTP_FLAG_REFRESH")]
            WINHTTP_FLAG_REFRESH = WINHTTP_FLAG_BYPASS_PROXY_CACHE,
            [Description("WINHTTP_FLAG_ESCAPE_DISABLE")]
            WINHTTP_FLAG_ESCAPE_DISABLE = 0x00000040,
            [Description("WINHTTP_FLAG_ESCAPE_DISABLE_QUERY")]
            WINHTTP_FLAG_ESCAPE_DISABLE_QUERY = 0x00000080,
            [Description("SECURITY_FLAG_IGNORE_UNKNOWN_CA")]
            SECURITY_FLAG_IGNORE_UNKNOWN_CA = 0x00000100,
            [Description("SECURITY_FLAG_IGNORE_CERT_DATE_INVALID")]
            SECURITY_FLAG_IGNORE_CERT_DATE_INVALID = 0x00002000,
            [Description("SECURITY_FLAG_IGNORE_CERT_CN_INVALID")]
            SECURITY_FLAG_IGNORE_CERT_CN_INVALID = 0x00001000,
            [Description("SECURITY_FLAG_IGNORE_CERT_WRONG_USAGE")]
            SECURITY_FLAG_IGNORE_CERT_WRONG_USAGE = 0x00000200,
        }
        public enum AutoProxyFlags : uint
        {
            [Description("WINHTTP_AUTOPROXY_AUTO_DETECT")]
            WINHTTP_AUTOPROXY_AUTO_DETECT = 0x00000001,
            [Description("WINHTTP_AUTOPROXY_CONFIG_URL")]
            WINHTTP_AUTOPROXY_CONFIG_URL = 0x00000002,
            [Description("WINHTTP_AUTOPROXY_HOST_KEEPCASE")]
            WINHTTP_AUTOPROXY_HOST_KEEPCASE = 0x00000004,
            [Description("WINHTTP_AUTOPROXY_HOST_LOWERCASE")]
            WINHTTP_AUTOPROXY_HOST_LOWERCASE = 0x00000008,
            [Description("WINHTTP_AUTOPROXY_RUN_INPROCESS")]
            WINHTTP_AUTOPROXY_RUN_INPROCESS = 0x00010000,
            [Description("WINHTTP_AUTOPROXY_RUN_OUTPROCESS_ONLY")]
            WINHTTP_AUTOPROXY_RUN_OUTPROCESS_ONLY = 0x00020000,
            [Description("WINHTTP_AUTOPROXY_NO_DIRECTACCESS")]
            WINHTTP_AUTOPROXY_NO_DIRECTACCESS = 0x00040000,
            [Description("WINHTTP_AUTOPROXY_NO_CACHE_CLIENT")]
            WINHTTP_AUTOPROXY_NO_CACHE_CLIENT = 0x00080000,
            [Description("WINHTTP_AUTOPROXY_NO_CACHE_SVC")]
            WINHTTP_AUTOPROXY_NO_CACHE_SVC = 0x00100000,
            [Description("WINHTTP_AUTOPROXY_SORT_RESULTS")]
            WINHTTP_AUTOPROXY_SORT_RESULTS = 0x00400000,
        }
        public enum AutoDetectFlags : uint
        {
            [Description("WINHTTP_AUTO_DETECT_TYPE_DHCP")]
            WINHTTP_AUTO_DETECT_TYPE_DHCP = 0x00000001,
            [Description("WINHTTP_AUTO_DETECT_TYPE_DNS_A")]
            WINHTTP_AUTO_DETECT_TYPE_DNS_A = 0x00000002,
        }
        public enum SetAndQueryFlags : uint
        {
            [Description("WINHTTP_OPTION_CALLBACK")]
            WINHTTP_OPTION_CALLBACK = 1,
            [Description("WINHTTP_OPTION_RESOLVE_TIMEOUT")]
            WINHTTP_OPTION_RESOLVE_TIMEOUT = 2,
            [Description("WINHTTP_OPTION_CONNECT_TIMEOUT")]
            WINHTTP_OPTION_CONNECT_TIMEOUT = 3,
            [Description("WINHTTP_OPTION_CONNECT_RETRIES")]
            WINHTTP_OPTION_CONNECT_RETRIES = 4,
            [Description("WINHTTP_OPTION_SEND_TIMEOUT")]
            WINHTTP_OPTION_SEND_TIMEOUT = 5,
            [Description("WINHTTP_OPTION_RECEIVE_TIMEOUT")]
            WINHTTP_OPTION_RECEIVE_TIMEOUT = 6,
            [Description("WINHTTP_OPTION_RECEIVE_RESPONSE_TIMEOUT")]
            WINHTTP_OPTION_RECEIVE_RESPONSE_TIMEOUT = 7,
            [Description("WINHTTP_OPTION_HANDLE_TYPE")]
            WINHTTP_OPTION_HANDLE_TYPE = 9,
            [Description("WINHTTP_OPTION_READ_BUFFER_SIZE")]
            WINHTTP_OPTION_READ_BUFFER_SIZE = 12,
            [Description("WINHTTP_OPTION_WRITE_BUFFER_SIZE")]
            WINHTTP_OPTION_WRITE_BUFFER_SIZE = 13,
            [Description("WINHTTP_OPTION_PARENT_HANDLE")]
            WINHTTP_OPTION_PARENT_HANDLE = 21,
            [Description("WINHTTP_OPTION_EXTENDED_ERROR")]
            WINHTTP_OPTION_EXTENDED_ERROR = 24,
            [Description("WINHTTP_OPTION_SECURITY_FLAGS")]
            WINHTTP_OPTION_SECURITY_FLAGS = 31,
            [Description("WINHTTP_OPTION_SECURITY_CERTIFICATE_STRUCT")]
            WINHTTP_OPTION_SECURITY_CERTIFICATE_STRUCT = 32,
            [Description("WINHTTP_OPTION_URL")]
            WINHTTP_OPTION_URL = 34,
            [Description("WINHTTP_OPTION_SECURITY_KEY_BITNESS")]
            WINHTTP_OPTION_SECURITY_KEY_BITNESS = 36,
            [Description("WINHTTP_OPTION_PROXY")]
            WINHTTP_OPTION_PROXY = 38,
            [Description("WINHTTP_OPTION_PROXY_RESULT_ENTRY")]
            WINHTTP_OPTION_PROXY_RESULT_ENTRY = 39,
            [Description("WINHTTP_OPTION_USER_AGENT")]
            WINHTTP_OPTION_USER_AGENT = 41,
            [Description("WINHTTP_OPTION_CONTEXT_VALUE")]
            WINHTTP_OPTION_CONTEXT_VALUE = 45,
            [Description("WINHTTP_OPTION_CLIENT_CERT_CONTEXT")]
            WINHTTP_OPTION_CLIENT_CERT_CONTEXT = 47,
            [Description("WINHTTP_OPTION_REQUEST_PRIORITY")]
            WINHTTP_OPTION_REQUEST_PRIORITY = 58,
            [Description("WINHTTP_OPTION_HTTP_VERSION")]
            WINHTTP_OPTION_HTTP_VERSION = 59,
            [Description("WINHTTP_OPTION_DISABLE_FEATURE")]
            WINHTTP_OPTION_DISABLE_FEATURE = 63,
            [Description("WINHTTP_OPTION_CODEPAGE")]
            WINHTTP_OPTION_CODEPAGE = 68,
            [Description("WINHTTP_OPTION_MAX_CONNS_PER_SERVER")]
            WINHTTP_OPTION_MAX_CONNS_PER_SERVER = 73,
            [Description("WINHTTP_OPTION_MAX_CONNS_PER_1_0_SERVER")]
            WINHTTP_OPTION_MAX_CONNS_PER_1_0_SERVER = 74,
            [Description("WINHTTP_OPTION_AUTOLOGON_POLICY")]
            WINHTTP_OPTION_AUTOLOGON_POLICY = 77,
            [Description("WINHTTP_OPTION_SERVER_CERT_CONTEXT")]
            WINHTTP_OPTION_SERVER_CERT_CONTEXT = 78,
            [Description("WINHTTP_OPTION_ENABLE_FEATURE")]
            WINHTTP_OPTION_ENABLE_FEATURE = 79,
            [Description("WINHTTP_OPTION_WORKER_THREAD_COUNT")]
            WINHTTP_OPTION_WORKER_THREAD_COUNT = 80,
            [Description("WINHTTP_OPTION_PASSPORT_COBRANDING_TEXT")]
            WINHTTP_OPTION_PASSPORT_COBRANDING_TEXT = 81,
            [Description("WINHTTP_OPTION_PASSPORT_COBRANDING_URL")]
            WINHTTP_OPTION_PASSPORT_COBRANDING_URL = 82,
            [Description("WINHTTP_OPTION_CONFIGURE_PASSPORT_AUTH")]
            WINHTTP_OPTION_CONFIGURE_PASSPORT_AUTH = 83,
            [Description("WINHTTP_OPTION_SECURE_PROTOCOLS")]
            WINHTTP_OPTION_SECURE_PROTOCOLS = 84,
            [Description("WINHTTP_OPTION_ENABLETRACING")]
            WINHTTP_OPTION_ENABLETRACING = 85,
            [Description("WINHTTP_OPTION_PASSPORT_SIGN_OUT")]
            WINHTTP_OPTION_PASSPORT_SIGN_OUT = 86,
            [Description("WINHTTP_OPTION_PASSPORT_RETURN_URL")]
            WINHTTP_OPTION_PASSPORT_RETURN_URL = 87,
            [Description("WINHTTP_OPTION_REDIRECT_POLICY")]
            WINHTTP_OPTION_REDIRECT_POLICY = 88,
            [Description("WINHTTP_OPTION_MAX_HTTP_AUTOMATIC_REDIRECTS")]
            WINHTTP_OPTION_MAX_HTTP_AUTOMATIC_REDIRECTS = 89,
            [Description("WINHTTP_OPTION_MAX_HTTP_STATUS_CONTINUE")]
            WINHTTP_OPTION_MAX_HTTP_STATUS_CONTINUE = 90,
            [Description("WINHTTP_OPTION_MAX_RESPONSE_HEADER_SIZE")]
            WINHTTP_OPTION_MAX_RESPONSE_HEADER_SIZE = 91,
            [Description("WINHTTP_OPTION_MAX_RESPONSE_DRAIN_SIZE")]
            WINHTTP_OPTION_MAX_RESPONSE_DRAIN_SIZE = 92,
            [Description("WINHTTP_OPTION_CONNECTION_INFO")]
            WINHTTP_OPTION_CONNECTION_INFO = 93,
            [Description("WINHTTP_OPTION_CLIENT_CERT_ISSUER_LIST")]
            WINHTTP_OPTION_CLIENT_CERT_ISSUER_LIST = 94,
            [Description("WINHTTP_OPTION_SPN")]
            WINHTTP_OPTION_SPN = 96,
            [Description("WINHTTP_OPTION_GLOBAL_PROXY_CREDS")]
            WINHTTP_OPTION_GLOBAL_PROXY_CREDS = 97,
            [Description("WINHTTP_OPTION_GLOBAL_SERVER_CREDS")]
            WINHTTP_OPTION_GLOBAL_SERVER_CREDS = 98,
            [Description("WINHTTP_OPTION_UNLOAD_NOTIFY_EVENT")]
            WINHTTP_OPTION_UNLOAD_NOTIFY_EVENT = 99,
            [Description("WINHTTP_OPTION_REJECT_USERPWD_IN_URL")]
            WINHTTP_OPTION_REJECT_USERPWD_IN_URL = 100,
            [Description("WINHTTP_OPTION_USE_GLOBAL_SERVER_CREDENTIALS")]
            WINHTTP_OPTION_USE_GLOBAL_SERVER_CREDENTIALS = 101,
            [Description("WINHTTP_OPTION_RECEIVE_PROXY_CONNECT_RESPONSE")]
            WINHTTP_OPTION_RECEIVE_PROXY_CONNECT_RESPONSE = 103,
            [Description("WINHTTP_OPTION_IS_PROXY_CONNECT_RESPONSE")]
            WINHTTP_OPTION_IS_PROXY_CONNECT_RESPONSE = 104,
            [Description("WINHTTP_OPTION_SERVER_SPN_USED")]
            WINHTTP_OPTION_SERVER_SPN_USED = 106,
            [Description("WINHTTP_OPTION_PROXY_SPN_USED")]
            WINHTTP_OPTION_PROXY_SPN_USED = 107,
            [Description("WINHTTP_OPTION_SERVER_CBT")]
            WINHTTP_OPTION_SERVER_CBT = 108,
            [Description("WINHTTP_OPTION_UNSAFE_HEADER_PARSING")]
            WINHTTP_OPTION_UNSAFE_HEADER_PARSING = 110,
            [Description("WINHTTP_OPTION_ASSURED_NON_BLOCKING_CALLBACKS")]
            WINHTTP_OPTION_ASSURED_NON_BLOCKING_CALLBACKS = 111,
            [Description("WINHTTP_OPTION_UPGRADE_TO_WEB_SOCKET")]
            WINHTTP_OPTION_UPGRADE_TO_WEB_SOCKET = 114,
            [Description("WINHTTP_OPTION_WEB_SOCKET_CLOSE_TIMEOUT")]
            WINHTTP_OPTION_WEB_SOCKET_CLOSE_TIMEOUT = 115,
            [Description("WINHTTP_OPTION_WEB_SOCKET_KEEPALIVE_INTERVAL")]
            WINHTTP_OPTION_WEB_SOCKET_KEEPALIVE_INTERVAL = 116,
            [Description("WINHTTP_OPTION_DECOMPRESSION")]
            WINHTTP_OPTION_DECOMPRESSION = 118,
            [Description("WINHTTP_OPTION_WEB_SOCKET_RECEIVE_BUFFER_SIZE")]
            WINHTTP_OPTION_WEB_SOCKET_RECEIVE_BUFFER_SIZE = 122,
            [Description("WINHTTP_OPTION_WEB_SOCKET_SEND_BUFFER_SIZE")]
            WINHTTP_OPTION_WEB_SOCKET_SEND_BUFFER_SIZE = 123,
            [Description("WINHTTP_LAST_OPTION")]
            WINHTTP_LAST_OPTION = WINHTTP_OPTION_WEB_SOCKET_SEND_BUFFER_SIZE,
            [Description("WINHTTP_OPTION_USERNAME")]
            WINHTTP_OPTION_USERNAME = 0x1000,
            [Description("WINHTTP_OPTION_PASSWORD")]
            WINHTTP_OPTION_PASSWORD = 0x1001,
            [Description("WINHTTP_OPTION_PROXY_USERNAME")]
            WINHTTP_OPTION_PROXY_USERNAME = 0x1002,
            [Description("WINHTTP_OPTION_PROXY_PASSWORD")]
            WINHTTP_OPTION_PROXY_PASSWORD = 0x1003,
        }
        public enum DecompressionFlags : uint
        {
            [Description("WINHTTP_DECOMPRESSION_FLAG_GZIP")]
            WINHTTP_DECOMPRESSION_FLAG_GZIP = 0x00000001,
            [Description("WINHTTP_DECOMPRESSION_FLAG_DEFLATE")]
            WINHTTP_DECOMPRESSION_FLAG_DEFLATE = 0x00000002,
            [Description("WINHTTP_DECOMPRESSION_FLAG_ALL")]
            WINHTTP_DECOMPRESSION_FLAG_ALL = WINHTTP_DECOMPRESSION_FLAG_GZIP | WINHTTP_DECOMPRESSION_FLAG_DEFLATE
        }
        public enum AutoLoginSecurityLevel : uint
        {
            [Description("WINHTTP_AUTOLOGON_SECURITY_LEVEL_MEDIUM")]
            WINHTTP_AUTOLOGON_SECURITY_LEVEL_MEDIUM = 0,
            [Description("WINHTTP_AUTOLOGON_SECURITY_LEVEL_LOW")]
            WINHTTP_AUTOLOGON_SECURITY_LEVEL_LOW = 1,
            [Description("WINHTTP_AUTOLOGON_SECURITY_LEVEL_HIGH")]
            WINHTTP_AUTOLOGON_SECURITY_LEVEL_HIGH = 2,
            [Description("WINHTTP_AUTOLOGON_SECURITY_LEVEL_DEFAULT")]
            WINHTTP_AUTOLOGON_SECURITY_LEVEL_DEFAULT = WINHTTP_AUTOLOGON_SECURITY_LEVEL_MEDIUM
        }
        public enum HandleTypes : uint
        {
            [Description("WINHTTP_HANDLE_TYPE_SESSION")]
            WINHTTP_HANDLE_TYPE_SESSION = 1,
            [Description("WINHTTP_HANDLE_TYPE_CONNECT")]
            WINHTTP_HANDLE_TYPE_CONNECT = 2,
            [Description("WINHTTP_HANDLE_TYPE_REQUEST")]
            WINHTTP_HANDLE_TYPE_REQUEST = 3,
        }
        public enum AuthSchemes : uint
        {
            [Description("WINHTTP_AUTH_SCHEME_BASIC")]
            WINHTTP_AUTH_SCHEME_BASIC = 0x00000001,
            [Description("WINHTTP_AUTH_SCHEME_NTLM")]
            WINHTTP_AUTH_SCHEME_NTLM = 0x00000002,
            [Description("WINHTTP_AUTH_SCHEME_PASSPORT")]
            WINHTTP_AUTH_SCHEME_PASSPORT = 0x00000004,
            [Description("WINHTTP_AUTH_SCHEME_DIGEST")]
            WINHTTP_AUTH_SCHEME_DIGEST = 0x00000008,
            [Description("WINHTTP_AUTH_SCHEME_NEGOTIATE")]
            WINHTTP_AUTH_SCHEME_NEGOTIATE = 0x00000010,
        }
        public enum AuthTargets : uint
        {
            [Description("WINHTTP_AUTH_TARGET_SERVER")]
            WINHTTP_AUTH_TARGET_SERVER = 0x00000000,
            [Description("WINHTTP_AUTH_TARGET_PROXY")]
            WINHTTP_AUTH_TARGET_PROXY = 0x00000001,
        }
        public enum SecurityFlags : uint
        {
            [Description("SECURITY_FLAG_SECURE")]
            SECURITY_FLAG_SECURE = 0x00000001,
            [Description("SECURITY_FLAG_STRENGTH_WEAK")]
            SECURITY_FLAG_STRENGTH_WEAK = 0x10000000,
            [Description("SECURITY_FLAG_STRENGTH_MEDIUM")]
            SECURITY_FLAG_STRENGTH_MEDIUM = 0x40000000,
            [Description("SECURITY_FLAG_STRENGTH_STRONG")]
            SECURITY_FLAG_STRENGTH_STRONG = 0x20000000,
        }
        public enum SecureProtocolFlags : uint
        {
            [Description("WINHTTP_FLAG_SECURE_PROTOCOL_SSL2")]
            WINHTTP_FLAG_SECURE_PROTOCOL_SSL2 = 0x00000008,
            [Description("WINHTTP_FLAG_SECURE_PROTOCOL_SSL3")]
            WINHTTP_FLAG_SECURE_PROTOCOL_SSL3 = 0x00000020,
            [Description("WINHTTP_FLAG_SECURE_PROTOCOL_TLS1")]
            WINHTTP_FLAG_SECURE_PROTOCOL_TLS1 = 0x00000080,
            [Description("WINHTTP_FLAG_SECURE_PROTOCOL_TLS1_1")]
            WINHTTP_FLAG_SECURE_PROTOCOL_TLS1_1 = 0x00000200,
            [Description("WINHTTP_FLAG_SECURE_PROTOCOL_TLS1_2")]
            WINHTTP_FLAG_SECURE_PROTOCOL_TLS1_2 = 0x00000800,
            [Description("WINHTTP_FLAG_SECURE_PROTOCOL_ALL")]
            WINHTTP_FLAG_SECURE_PROTOCOL_ALL =
                WINHTTP_FLAG_SECURE_PROTOCOL_SSL2 | WINHTTP_FLAG_SECURE_PROTOCOL_SSL3 | WINHTTP_FLAG_SECURE_PROTOCOL_TLS1 | WINHTTP_FLAG_SECURE_PROTOCOL_TLS1_1 | WINHTTP_FLAG_SECURE_PROTOCOL_TLS1_2
        }
        public enum QueryRawHeaders : uint
        {
            [Description("WINHTTP_QUERY_MIME_VERSION")]
            WINHTTP_QUERY_MIME_VERSION = 0,
            [Description("WINHTTP_QUERY_CONTENT_TYPE")]
            WINHTTP_QUERY_CONTENT_TYPE = 1,
            [Description("WINHTTP_QUERY_CONTENT_TRANSFER_ENCODING")]
            WINHTTP_QUERY_CONTENT_TRANSFER_ENCODING = 2,
            [Description("WINHTTP_QUERY_CONTENT_ID")]
            WINHTTP_QUERY_CONTENT_ID = 3,
            [Description("WINHTTP_QUERY_CONTENT_DESCRIPTION")]
            WINHTTP_QUERY_CONTENT_DESCRIPTION = 4,
            [Description("WINHTTP_QUERY_CONTENT_LENGTH")]
            WINHTTP_QUERY_CONTENT_LENGTH = 5,
            [Description("WINHTTP_QUERY_CONTENT_LANGUAGE")]
            WINHTTP_QUERY_CONTENT_LANGUAGE = 6,
            [Description("WINHTTP_QUERY_ALLOW")]
            WINHTTP_QUERY_ALLOW = 7,
            [Description("WINHTTP_QUERY_PUBLIC")]
            WINHTTP_QUERY_PUBLIC = 8,
            [Description("WINHTTP_QUERY_DATE")]
            WINHTTP_QUERY_DATE = 9,
            [Description("WINHTTP_QUERY_EXPIRES")]
            WINHTTP_QUERY_EXPIRES = 10,
            [Description("WINHTTP_QUERY_LAST_MODIFIED")]
            WINHTTP_QUERY_LAST_MODIFIED = 11,
            [Description("WINHTTP_QUERY_MESSAGE_ID")]
            WINHTTP_QUERY_MESSAGE_ID = 12,
            [Description("WINHTTP_QUERY_URI")]
            WINHTTP_QUERY_URI = 13,
            [Description("WINHTTP_QUERY_DERIVED_FROM")]
            WINHTTP_QUERY_DERIVED_FROM = 14,
            [Description("WINHTTP_QUERY_COST")]
            WINHTTP_QUERY_COST = 15,
            [Description("WINHTTP_QUERY_LINK")]
            WINHTTP_QUERY_LINK = 16,
            [Description("WINHTTP_QUERY_PRAGMA")]
            WINHTTP_QUERY_PRAGMA = 17,
            [Description("WINHTTP_QUERY_VERSION")]
            WINHTTP_QUERY_VERSION = 18,
            [Description("WINHTTP_QUERY_STATUS_CODE")]
            WINHTTP_QUERY_STATUS_CODE = 19,
            [Description("WINHTTP_QUERY_STATUS_TEXT")]
            WINHTTP_QUERY_STATUS_TEXT = 20,
            [Description("WINHTTP_QUERY_RAW_HEADERS")]
            WINHTTP_QUERY_RAW_HEADERS = 21,
            [Description("WINHTTP_QUERY_RAW_HEADERS_CRLF")]
            WINHTTP_QUERY_RAW_HEADERS_CRLF = 22,
            [Description("WINHTTP_QUERY_CONNECTION")]
            WINHTTP_QUERY_CONNECTION = 23,
            [Description("WINHTTP_QUERY_ACCEPT")]
            WINHTTP_QUERY_ACCEPT = 24,
            [Description("WINHTTP_QUERY_ACCEPT_CHARSET")]
            WINHTTP_QUERY_ACCEPT_CHARSET = 25,
            [Description("WINHTTP_QUERY_ACCEPT_ENCODING")]
            WINHTTP_QUERY_ACCEPT_ENCODING = 26,
            [Description("WINHTTP_QUERY_ACCEPT_LANGUAGE")]
            WINHTTP_QUERY_ACCEPT_LANGUAGE = 27,
            [Description("WINHTTP_QUERY_AUTHORIZATION")]
            WINHTTP_QUERY_AUTHORIZATION = 28,
            [Description("WINHTTP_QUERY_CONTENT_ENCODING")]
            WINHTTP_QUERY_CONTENT_ENCODING = 29,
            [Description("WINHTTP_QUERY_FORWARDED")]
            WINHTTP_QUERY_FORWARDED = 30,
            [Description("WINHTTP_QUERY_FROM")]
            WINHTTP_QUERY_FROM = 31,
            [Description("WINHTTP_QUERY_IF_MODIFIED_SINCE")]
            WINHTTP_QUERY_IF_MODIFIED_SINCE = 32,
            [Description("WINHTTP_QUERY_LOCATION")]
            WINHTTP_QUERY_LOCATION = 33,
            [Description("WINHTTP_QUERY_ORIG_URI")]
            WINHTTP_QUERY_ORIG_URI = 34,
            [Description("WINHTTP_QUERY_REFERER")]
            WINHTTP_QUERY_REFERER = 35,
            [Description("WINHTTP_QUERY_RETRY_AFTER")]
            WINHTTP_QUERY_RETRY_AFTER = 36,
            [Description("WINHTTP_QUERY_SERVER")]
            WINHTTP_QUERY_SERVER = 37,
            [Description("WINHTTP_QUERY_TITLE")]
            WINHTTP_QUERY_TITLE = 38,
            [Description("WINHTTP_QUERY_USER_AGENT")]
            WINHTTP_QUERY_USER_AGENT = 39,
            [Description("WINHTTP_QUERY_WWW_AUTHENTICATE")]
            WINHTTP_QUERY_WWW_AUTHENTICATE = 40,
            [Description("WINHTTP_QUERY_PROXY_AUTHENTICATE")]
            WINHTTP_QUERY_PROXY_AUTHENTICATE = 41,
            [Description("WINHTTP_QUERY_ACCEPT_RANGES")]
            WINHTTP_QUERY_ACCEPT_RANGES = 42,
            [Description("WINHTTP_QUERY_SET_COOKIE")]
            WINHTTP_QUERY_SET_COOKIE = 43,
            [Description("WINHTTP_QUERY_COOKIE")]
            WINHTTP_QUERY_COOKIE = 44,
            [Description("WINHTTP_QUERY_REQUEST_METHOD")]
            WINHTTP_QUERY_REQUEST_METHOD = 45,
            [Description("WINHTTP_QUERY_REFRESH")]
            WINHTTP_QUERY_REFRESH = 46,
            [Description("WINHTTP_QUERY_CONTENT_DISPOSITION")]
            WINHTTP_QUERY_CONTENT_DISPOSITION = 47,
        }
        public enum Http11Headers : uint
        {
            [Description("WINHTTP_QUERY_AGE")]
            WINHTTP_QUERY_AGE = 48,
            [Description("WINHTTP_QUERY_CACHE_CONTROL")]
            WINHTTP_QUERY_CACHE_CONTROL = 49,
            [Description("WINHTTP_QUERY_CONTENT_BASE")]
            WINHTTP_QUERY_CONTENT_BASE = 50,
            [Description("WINHTTP_QUERY_CONTENT_LOCATION")]
            WINHTTP_QUERY_CONTENT_LOCATION = 51,
            [Description("WINHTTP_QUERY_CONTENT_MD5")]
            WINHTTP_QUERY_CONTENT_MD5 = 52,
            [Description("WINHTTP_QUERY_CONTENT_RANGE")]
            WINHTTP_QUERY_CONTENT_RANGE = 53,
            [Description("WINHTTP_QUERY_ETAG")]
            WINHTTP_QUERY_ETAG = 54,
            [Description("WINHTTP_QUERY_HOST")]
            WINHTTP_QUERY_HOST = 55,
            [Description("WINHTTP_QUERY_IF_MATCH")]
            WINHTTP_QUERY_IF_MATCH = 56,
            [Description("WINHTTP_QUERY_IF_NONE_MATCH")]
            WINHTTP_QUERY_IF_NONE_MATCH = 57,
            [Description("WINHTTP_QUERY_IF_RANGE")]
            WINHTTP_QUERY_IF_RANGE = 58,
            [Description("WINHTTP_QUERY_IF_UNMODIFIED_SINCE")]
            WINHTTP_QUERY_IF_UNMODIFIED_SINCE = 59,
            [Description("WINHTTP_QUERY_MAX_FORWARDS")]
            WINHTTP_QUERY_MAX_FORWARDS = 60,
            [Description("WINHTTP_QUERY_PROXY_AUTHORIZATION")]
            WINHTTP_QUERY_PROXY_AUTHORIZATION = 61,
            [Description("WINHTTP_QUERY_RANGE")]
            WINHTTP_QUERY_RANGE = 62,
            [Description("WINHTTP_QUERY_TRANSFER_ENCODING")]
            WINHTTP_QUERY_TRANSFER_ENCODING = 63,
            [Description("WINHTTP_QUERY_UPGRADE")]
            WINHTTP_QUERY_UPGRADE = 64,
            [Description("WINHTTP_QUERY_VARY")]
            WINHTTP_QUERY_VARY = 65,
            [Description("WINHTTP_QUERY_VIA")]
            WINHTTP_QUERY_VIA = 66,
            [Description("WINHTTP_QUERY_WARNING")]
            WINHTTP_QUERY_WARNING = 67,
            [Description("WINHTTP_QUERY_EXPECT")]
            WINHTTP_QUERY_EXPECT = 68,
            [Description("WINHTTP_QUERY_PROXY_CONNECTION")]
            WINHTTP_QUERY_PROXY_CONNECTION = 69,
            [Description("WINHTTP_QUERY_UNLESS_MODIFIED_SINCE")]
            WINHTTP_QUERY_UNLESS_MODIFIED_SINCE = 70,
            [Description("WINHTTP_QUERY_PROXY_SUPPORT")]
            WINHTTP_QUERY_PROXY_SUPPORT = 75,
            [Description("WINHTTP_QUERY_AUTHENTICATION_INFO")]
            WINHTTP_QUERY_AUTHENTICATION_INFO = 76,
            [Description("WINHTTP_QUERY_PASSPORT_URLS")]
            WINHTTP_QUERY_PASSPORT_URLS = 77,
            [Description("WINHTTP_QUERY_PASSPORT_CONFIG")]
            WINHTTP_QUERY_PASSPORT_CONFIG = 78,
            [Description("WINHTTP_QUERY_MAX")]
            WINHTTP_QUERY_MAX = 78,
        }
        public enum HttpStatusCodes : uint
        {
            [Description("HTTP_STATUS_CONTINUE")]
            HTTP_STATUS_CONTINUE = 100,
            [Description("HTTP_STATUS_SWITCH_PROTOCOLS")]
            HTTP_STATUS_SWITCH_PROTOCOLS = 101,
            [Description("HTTP_STATUS_OK")]
            HTTP_STATUS_OK = 200,
            [Description("HTTP_STATUS_CREATED")]
            HTTP_STATUS_CREATED = 201,
            [Description("HTTP_STATUS_ACCEPTED")]
            HTTP_STATUS_ACCEPTED = 202,
            [Description("HTTP_STATUS_PARTIAL")]
            HTTP_STATUS_PARTIAL = 203,
            [Description("HTTP_STATUS_NO_CONTENT")]
            HTTP_STATUS_NO_CONTENT = 204,
            [Description("HTTP_STATUS_RESET_CONTENT")]
            HTTP_STATUS_RESET_CONTENT = 205,
            [Description("HTTP_STATUS_PARTIAL_CONTENT")]
            HTTP_STATUS_PARTIAL_CONTENT = 206,
            [Description("HTTP_STATUS_WEBDAV_MULTI_STATUS")]
            HTTP_STATUS_WEBDAV_MULTI_STATUS = 207,
            [Description("HTTP_STATUS_AMBIGUOUS")]
            HTTP_STATUS_AMBIGUOUS = 300,
            [Description("HTTP_STATUS_MOVED")]
            HTTP_STATUS_MOVED = 301,
            [Description("HTTP_STATUS_REDIRECT")]
            HTTP_STATUS_REDIRECT = 302,
            [Description("HTTP_STATUS_REDIRECT_METHOD")]
            HTTP_STATUS_REDIRECT_METHOD = 303,
            [Description("HTTP_STATUS_NOT_MODIFIED")]
            HTTP_STATUS_NOT_MODIFIED = 304,
            [Description("HTTP_STATUS_USE_PROXY")]
            HTTP_STATUS_USE_PROXY = 305,
            [Description("HTTP_STATUS_REDIRECT_KEEP_VERB")]
            HTTP_STATUS_REDIRECT_KEEP_VERB = 307,
            [Description("HTTP_STATUS_BAD_REQUEST")]
            HTTP_STATUS_BAD_REQUEST = 400,
            [Description("HTTP_STATUS_DENIED")]
            HTTP_STATUS_DENIED = 401,
            [Description("HTTP_STATUS_PAYMENT_REQ")]
            HTTP_STATUS_PAYMENT_REQ = 402,
            [Description("HTTP_STATUS_FORBIDDEN")]
            HTTP_STATUS_FORBIDDEN = 403,
            [Description("HTTP_STATUS_NOT_FOUND")]
            HTTP_STATUS_NOT_FOUND = 404,
            [Description("HTTP_STATUS_BAD_METHOD")]
            HTTP_STATUS_BAD_METHOD = 405,
            [Description("HTTP_STATUS_NONE_ACCEPTABLE")]
            HTTP_STATUS_NONE_ACCEPTABLE = 406,
            [Description("HTTP_STATUS_PROXY_AUTH_REQ")]
            HTTP_STATUS_PROXY_AUTH_REQ = 407,
            [Description("HTTP_STATUS_REQUEST_TIMEOUT")]
            HTTP_STATUS_REQUEST_TIMEOUT = 408,
            [Description("HTTP_STATUS_CONFLICT")]
            HTTP_STATUS_CONFLICT = 409,
            [Description("HTTP_STATUS_GONE")]
            HTTP_STATUS_GONE = 410,
            [Description("HTTP_STATUS_LENGTH_REQUIRED")]
            HTTP_STATUS_LENGTH_REQUIRED = 411,
            [Description("HTTP_STATUS_PRECOND_FAILED")]
            HTTP_STATUS_PRECOND_FAILED = 412,
            [Description("HTTP_STATUS_REQUEST_TOO_LARGE")]
            HTTP_STATUS_REQUEST_TOO_LARGE = 413,
            [Description("HTTP_STATUS_URI_TOO_LONG")]
            HTTP_STATUS_URI_TOO_LONG = 414,
            [Description("HTTP_STATUS_UNSUPPORTED_MEDIA")]
            HTTP_STATUS_UNSUPPORTED_MEDIA = 415,
            [Description("HTTP_STATUS_RETRY_WITH")]
            HTTP_STATUS_RETRY_WITH = 449,
            [Description("HTTP_STATUS_SERVER_ERROR")]
            HTTP_STATUS_SERVER_ERROR = 500,
            [Description("HTTP_STATUS_NOT_SUPPORTED")]
            HTTP_STATUS_NOT_SUPPORTED = 501,
            [Description("HTTP_STATUS_BAD_GATEWAY")]
            HTTP_STATUS_BAD_GATEWAY = 502,
            [Description("HTTP_STATUS_SERVICE_UNAVAIL")]
            HTTP_STATUS_SERVICE_UNAVAIL = 503,
            [Description("HTTP_STATUS_GATEWAY_TIMEOUT")]
            HTTP_STATUS_GATEWAY_TIMEOUT = 504,
            [Description("HTTP_STATUS_VERSION_NOT_SUP")]
            HTTP_STATUS_VERSION_NOT_SUP = 505,
            [Description("HTTP_STATUS_FIRST")]
            HTTP_STATUS_FIRST = HTTP_STATUS_CONTINUE,
            [Description("HTTP_STATUS_LAST")]
            HTTP_STATUS_LAST = HTTP_STATUS_VERSION_NOT_SUP,
        }
        public enum AddRequestHeaderFlags : uint
        {
            [Description("WINHTTP_ADDREQ_INDEX_MASK")]
            WINHTTP_ADDREQ_INDEX_MASK = 0x0000FFFF,
            [Description("WINHTTP_ADDREQ_FLAGS_MASK")]
            WINHTTP_ADDREQ_FLAGS_MASK = 0xFFFF0000,
        }
        public const int WINHTTP_ERROR_BASE = 12000;
        public enum ErrorCodes
        {
            [Description("ERROR_WINHTTP_OUT_OF_HANDLES")]
            ERROR_WINHTTP_OUT_OF_HANDLES = (WINHTTP_ERROR_BASE + 1),
            [Description("ERROR_WINHTTP_TIMEOUT")]
            ERROR_WINHTTP_TIMEOUT = (WINHTTP_ERROR_BASE + 2),
            [Description("ERROR_WINHTTP_INTERNAL_ERROR")]
            ERROR_WINHTTP_INTERNAL_ERROR = (WINHTTP_ERROR_BASE + 4),
            [Description("ERROR_WINHTTP_INVALID_URL")]
            ERROR_WINHTTP_INVALID_URL = (WINHTTP_ERROR_BASE + 5),
            [Description("ERROR_WINHTTP_UNRECOGNIZED_SCHEME")]
            ERROR_WINHTTP_UNRECOGNIZED_SCHEME = (WINHTTP_ERROR_BASE + 6),
            [Description("ERROR_WINHTTP_NAME_NOT_RESOLVED")]
            ERROR_WINHTTP_NAME_NOT_RESOLVED = (WINHTTP_ERROR_BASE + 7),
            [Description("ERROR_WINHTTP_INVALID_OPTION")]
            ERROR_WINHTTP_INVALID_OPTION = (WINHTTP_ERROR_BASE + 9),
            [Description("ERROR_WINHTTP_OPTION_NOT_SETTABLE")]
            ERROR_WINHTTP_OPTION_NOT_SETTABLE = (WINHTTP_ERROR_BASE + 11),
            [Description("ERROR_WINHTTP_SHUTDOWN")]
            ERROR_WINHTTP_SHUTDOWN = (WINHTTP_ERROR_BASE + 12),
            [Description("ERROR_WINHTTP_LOGIN_FAILURE")]
            ERROR_WINHTTP_LOGIN_FAILURE = (WINHTTP_ERROR_BASE + 15),
            [Description("ERROR_WINHTTP_OPERATION_CANCELLED")]
            ERROR_WINHTTP_OPERATION_CANCELLED = (WINHTTP_ERROR_BASE + 17),
            [Description("ERROR_WINHTTP_INCORRECT_HANDLE_TYPE")]
            ERROR_WINHTTP_INCORRECT_HANDLE_TYPE = (WINHTTP_ERROR_BASE + 18),
            [Description("ERROR_WINHTTP_INCORRECT_HANDLE_STATE")]
            ERROR_WINHTTP_INCORRECT_HANDLE_STATE = (WINHTTP_ERROR_BASE + 19),
            [Description("ERROR_WINHTTP_CANNOT_CONNECT")]
            ERROR_WINHTTP_CANNOT_CONNECT = (WINHTTP_ERROR_BASE + 29),
            [Description("ERROR_WINHTTP_CONNECTION_ERROR")]
            ERROR_WINHTTP_CONNECTION_ERROR = (WINHTTP_ERROR_BASE + 30),
            [Description("ERROR_WINHTTP_RESEND_REQUEST")]
            ERROR_WINHTTP_RESEND_REQUEST = (WINHTTP_ERROR_BASE + 32),
            [Description("ERROR_WINHTTP_CLIENT_AUTH_CERT_NEEDED")]
            ERROR_WINHTTP_CLIENT_AUTH_CERT_NEEDED = (WINHTTP_ERROR_BASE + 44),
            [Description("ERROR_WINHTTP_CANNOT_CALL_BEFORE_OPEN")]
            ERROR_WINHTTP_CANNOT_CALL_BEFORE_OPEN = (WINHTTP_ERROR_BASE + 100),
            [Description("ERROR_WINHTTP_CANNOT_CALL_BEFORE_SEND")]
            ERROR_WINHTTP_CANNOT_CALL_BEFORE_SEND = (WINHTTP_ERROR_BASE + 101),
            [Description("ERROR_WINHTTP_CANNOT_CALL_AFTER_SEND")]
            ERROR_WINHTTP_CANNOT_CALL_AFTER_SEND = (WINHTTP_ERROR_BASE + 102),
            [Description("ERROR_WINHTTP_CANNOT_CALL_AFTER_OPEN")]
            ERROR_WINHTTP_CANNOT_CALL_AFTER_OPEN = (WINHTTP_ERROR_BASE + 103),
            [Description("ERROR_WINHTTP_HEADER_NOT_FOUND")]
            ERROR_WINHTTP_HEADER_NOT_FOUND = (WINHTTP_ERROR_BASE + 150),
            [Description("ERROR_WINHTTP_INVALID_SERVER_RESPONSE")]
            ERROR_WINHTTP_INVALID_SERVER_RESPONSE = (WINHTTP_ERROR_BASE + 152),
            [Description("ERROR_WINHTTP_INVALID_HEADER")]
            ERROR_WINHTTP_INVALID_HEADER = (WINHTTP_ERROR_BASE + 153),
            [Description("ERROR_WINHTTP_INVALID_QUERY_REQUEST")]
            ERROR_WINHTTP_INVALID_QUERY_REQUEST = (WINHTTP_ERROR_BASE + 154),
            [Description("ERROR_WINHTTP_HEADER_ALREADY_EXISTS")]
            ERROR_WINHTTP_HEADER_ALREADY_EXISTS = (WINHTTP_ERROR_BASE + 155),
            [Description("ERROR_WINHTTP_REDIRECT_FAILED")]
            ERROR_WINHTTP_REDIRECT_FAILED = (WINHTTP_ERROR_BASE + 156),
            [Description("ERROR_WINHTTP_AUTO_PROXY_SERVICE_ERROR")]
            ERROR_WINHTTP_AUTO_PROXY_SERVICE_ERROR = (WINHTTP_ERROR_BASE + 178),
            [Description("ERROR_WINHTTP_BAD_AUTO_PROXY_SCRIPT")]
            ERROR_WINHTTP_BAD_AUTO_PROXY_SCRIPT = (WINHTTP_ERROR_BASE + 166),
            [Description("ERROR_WINHTTP_UNABLE_TO_DOWNLOAD_SCRIPT")]
            ERROR_WINHTTP_UNABLE_TO_DOWNLOAD_SCRIPT = (WINHTTP_ERROR_BASE + 167),
            [Description("ERROR_WINHTTP_UNHANDLED_SCRIPT_TYPE")]
            ERROR_WINHTTP_UNHANDLED_SCRIPT_TYPE = (WINHTTP_ERROR_BASE + 176),
            [Description("ERROR_WINHTTP_SCRIPT_EXECUTION_ERROR")]
            ERROR_WINHTTP_SCRIPT_EXECUTION_ERROR = (WINHTTP_ERROR_BASE + 177),
            [Description("ERROR_WINHTTP_NOT_INITIALIZED")]
            ERROR_WINHTTP_NOT_INITIALIZED = (WINHTTP_ERROR_BASE + 172),
            [Description("ERROR_WINHTTP_SECURE_FAILURE")]
            ERROR_WINHTTP_SECURE_FAILURE = (WINHTTP_ERROR_BASE + 175),
            [Description("ERROR_WINHTTP_SECURE_CERT_DATE_INVALID")]
            ERROR_WINHTTP_SECURE_CERT_DATE_INVALID = (WINHTTP_ERROR_BASE + 37),
            [Description("ERROR_WINHTTP_SECURE_CERT_CN_INVALID")]
            ERROR_WINHTTP_SECURE_CERT_CN_INVALID = (WINHTTP_ERROR_BASE + 38),
            [Description("ERROR_WINHTTP_SECURE_INVALID_CA")]
            ERROR_WINHTTP_SECURE_INVALID_CA = (WINHTTP_ERROR_BASE + 45),
            [Description("ERROR_WINHTTP_SECURE_CERT_REV_FAILED")]
            ERROR_WINHTTP_SECURE_CERT_REV_FAILED = (WINHTTP_ERROR_BASE + 57),
            [Description("ERROR_WINHTTP_SECURE_CHANNEL_ERROR")]
            ERROR_WINHTTP_SECURE_CHANNEL_ERROR = (WINHTTP_ERROR_BASE + 157),
            [Description("ERROR_WINHTTP_SECURE_INVALID_CERT")]
            ERROR_WINHTTP_SECURE_INVALID_CERT = (WINHTTP_ERROR_BASE + 169),
            [Description("ERROR_WINHTTP_SECURE_CERT_REVOKED")]
            ERROR_WINHTTP_SECURE_CERT_REVOKED = (WINHTTP_ERROR_BASE + 170),
            [Description("ERROR_WINHTTP_SECURE_CERT_WRONG_USAGE")]
            ERROR_WINHTTP_SECURE_CERT_WRONG_USAGE = (WINHTTP_ERROR_BASE + 179),
            [Description("ERROR_WINHTTP_AUTODETECTION_FAILED")]
            ERROR_WINHTTP_AUTODETECTION_FAILED = (WINHTTP_ERROR_BASE + 180),
            [Description("ERROR_WINHTTP_HEADER_COUNT_EXCEEDED")]
            ERROR_WINHTTP_HEADER_COUNT_EXCEEDED = (WINHTTP_ERROR_BASE + 181),
            [Description("ERROR_WINHTTP_HEADER_SIZE_OVERFLOW")]
            ERROR_WINHTTP_HEADER_SIZE_OVERFLOW = (WINHTTP_ERROR_BASE + 182),
            [Description("ERROR_WINHTTP_CHUNKED_ENCODING_HEADER_SIZE_OVERFLOW")]
            ERROR_WINHTTP_CHUNKED_ENCODING_HEADER_SIZE_OVERFLOW = (WINHTTP_ERROR_BASE + 183),
            [Description("ERROR_WINHTTP_RESPONSE_DRAIN_OVERFLOW")]
            ERROR_WINHTTP_RESPONSE_DRAIN_OVERFLOW = (WINHTTP_ERROR_BASE + 184),
            [Description("ERROR_WINHTTP_CLIENT_CERT_NO_PRIVATE_KEY")]
            ERROR_WINHTTP_CLIENT_CERT_NO_PRIVATE_KEY = (WINHTTP_ERROR_BASE + 185),
            [Description("ERROR_WINHTTP_CLIENT_CERT_NO_ACCESS_PRIVATE_KEY")]
            ERROR_WINHTTP_CLIENT_CERT_NO_ACCESS_PRIVATE_KEY = (WINHTTP_ERROR_BASE + 186),
            [Description("WINHTTP_ERROR_LAST")]
            WINHTTP_ERROR_LAST = (WINHTTP_ERROR_BASE + 186),
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct ProxyInfo
        {
            [MarshalAs(UnmanagedType.U4)]
            public AccessType dwAccessType;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszProxy;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszProxyBypass;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct AutoProxyOptions
        {
            [MarshalAs(UnmanagedType.U4)]
            public AutoProxyFlags dwFlags;
            [MarshalAs(UnmanagedType.U4)]
            public uint dwAutoDetectFlags;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszAutoConfigUrl;
            public System.IntPtr lpvReserved;
            public bool fAutoLogonIfChallenged;

        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct CurrentUserIEProxyConfig
        {
            public bool fAutoDetect;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszAutoConfigUrl;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszProxy;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszProxyBypass;
        }

        [DllImport("winhttp.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool WinHttpGetDefaultProxyConfiguration(ref ProxyInfo pProxyInfo);

        [DllImport("winhttp.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool WinHttpSetDefaultProxyConfiguration(ref ProxyInfo pProxyInfo);

        [DllImport("winhttp.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr WinHttpOpen(/*[MarshalAs(UnmanagedType.LPWStr)]*/ string pszAgentW, AccessType accessType, string pszProxyW, string pszProxyBypassW, OpenFlags dwFlags = OpenFlags.WINHTTP_FLAG_NONE);

        [DllImport("winhttp.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool WinHttpGetProxyForUrl(IntPtr hSession, string lpcwszUrl, ref AutoProxyOptions pAutoProxyOptions, ref ProxyInfo pProxyInfo);


        // "Nice" interface





        protected IntPtr hSession = IntPtr.Zero;

        public void Open(string pszAgentW, AccessType accessType, string pszProxyW, string pszProxyBypassW, OpenFlags dwFlags = OpenFlags.WINHTTP_FLAG_NONE)
        {
            hSession = WinHttpOpen(pszAgentW, accessType, pszProxyW, pszProxyBypassW, dwFlags);
            if (hSession == IntPtr.Zero)
            {
                // request failed
                int errorCode = Marshal.GetLastWin32Error();
                throw new WinHTTPException(errorCode);
            }
        }
        public ProxyInfo GetProxyForUrl(string lpcwszUrl, ref AutoProxyOptions pAutoProxyOptions)
        {
            ProxyInfo pProxyInfo = new WinHTTPdotNet.ProxyInfo();
            bool status = WinHttpGetProxyForUrl(hSession, lpcwszUrl, ref pAutoProxyOptions, ref pProxyInfo);
            if (!status)
            {
                // request failed
                int errorCode = Marshal.GetLastWin32Error();
                throw new WinHTTPException(errorCode);
            }
            return pProxyInfo;
        }


    }
    public class WinHTTPException : System.Exception
    {
        protected string winhttperr;
        public WinHTTPException(int code)
        {
            WinHTTPdotNet.ErrorCodes winHTTPerror = (WinHTTPdotNet.ErrorCodes)code;
            winhttperr = winHTTPerror.ToString();
        }
        public override string Message
        {
            get
            {
                return winhttperr;
            }
        }

    }
}
