// win32: UART

// https://ru.wikibooks.org/wiki/COM-%D0%BF%D0%BE%D1%80%D1%82_%D0%B2_Windows_(%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5)

#include <windows.h>
#include <assert.h>
#include "emCpp/UART.h"

UART::UART(const char *_SymName, unsigned int _baud) {
	baud = _baud;
	SymName = _SymName;

	// open port
	PortHandle = CreateFile(SymName, // lpFileName
			GENERIC_WRITE, // dwDesiredAccess
			0, // dwShareMode
			NULL, // lpSecurityAttributes
			OPEN_EXISTING, // dwCreationDistribution
			0, // dwFlagsAndAttributes sync:0/async:FILE_FLAG_OVERLAPPED
			NULL // hTemplateFile
			);
	assert(PortHandle != INVALID_HANDLE_VALUE);

	// set mode
	//	_DCB dcb; // data control block
	//	dcb.BaudRate=baud; // 4800
	//	dcb.ByteSize=8; // 8
	//	dcb.fParity=false; // N
	//	dcb.StopBits=1; // 1
	//	dcb.fBinary=true;
	//	dcb.DCBlength=sizeof(dcb);

}

UART::~UART() {
	CloseHandle(PortHandle);
}
