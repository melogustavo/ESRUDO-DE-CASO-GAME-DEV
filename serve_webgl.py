#!/usr/bin/env python3

import http.server, socketserver, sys, os

def main():
    if len(sys.argv) < 2:
        print("Uso: python serve_webgl.py <pasta_do_build> [porta]")
        sys.exit(1)
    root = os.path.abspath(sys.argv[1])
    port = int(sys.argv[2]) if len(sys.argv) > 2 else 8080
    os.chdir(root)
    handler = http.server.SimpleHTTPRequestHandler
    with socketserver.TCPServer(("", port), handler) as httpd:
        print(f"Servindo {root} em http://localhost:{port}")
        try:
            httpd.serve_forever()
        except KeyboardInterrupt:
            print("\nEncerrando servidor...")
            httpd.server_close()

if __name__ == "__main__":
    main()
