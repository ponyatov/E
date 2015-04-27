// win32: UART

// https://ru.wikibooks.org/wiki/COM-%D0%BF%D0%BE%D1%80%D1%82_%D0%B2_Windows_(%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5)

#include <windows.h>
#include <assert.h>
#include "emCpp/UART.h"

const int UART::TIMEOUT = 1000;

UART::UART(const char *_SymName, int _baud) {
	baud = _baud;
	SymName = _SymName;

	// open port
	PortHandle = CreateFile(SymName, // lpFileName
			GENERIC_READ | GENERIC_WRITE, // dwDesiredAccess
			0, // dwShareMode
			NULL, // lpSecurityAttributes
			OPEN_EXISTING, // dwCreationDistribution
			0, // dwFlagsAndAttributes sync:0/async:FILE_FLAG_OVERLAPPED
			NULL // hTemplateFile
			);
	assert(PortHandle != INVALID_HANDLE_VALUE);

	// set timeouts
	COMMTIMEOUTS CommTimeOuts;
	CommTimeOuts.ReadIntervalTimeout = 0xFFFFFFFF;
	CommTimeOuts.ReadTotalTimeoutMultiplier = 0;
	CommTimeOuts.ReadTotalTimeoutConstant = TIMEOUT;
	CommTimeOuts.WriteTotalTimeoutMultiplier = 0;
	CommTimeOuts.WriteTotalTimeoutConstant = TIMEOUT;
	SetCommTimeouts(PortHandle, &CommTimeOuts);

	// set mode 8N1
	_DCB dcb; // data control block
	memset(&dcb,0,sizeof(dcb)); dcb.DCBlength = sizeof(dcb);
	//// main params
	dcb.BaudRate = baud; // 4800
	dcb.ByteSize = 8; // 8
	dcb.fParity = NOPARITY; // N
	dcb.StopBits = ONESTOPBIT; // 1
	dcb.fBinary = true;
	//// misc params
	dcb.fAbortOnError = TRUE;
	dcb.fDtrControl = DTR_CONTROL_DISABLE;
	dcb.fRtsControl = RTS_CONTROL_DISABLE;
	dcb.fInX = FALSE;
	dcb.fOutX = FALSE;
	dcb.XonChar = 0;
	dcb.XoffChar = (unsigned char) 0xFF;
	dcb.fErrorChar = FALSE;
	dcb.fNull = FALSE;
	dcb.fOutxCtsFlow = FALSE;
	dcb.fOutxDsrFlow = FALSE;
	dcb.XonLim = 128;
	dcb.XoffLim = 128;
	SetCommState(PortHandle, &dcb);

}

UART::~UART() {
	CloseHandle(PortHandle);
}

bool UART::send(char *buf,unsigned int size) {
	DWORD feedback;
	return WriteFile(PortHandle,buf,size,&feedback,0) || feedback != size;
}
