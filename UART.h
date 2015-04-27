#ifndef _H_UART
#define _H_UART

class UART {
	unsigned int baud;
	HANDLE PortHandle;
public:
	const char *SymName;
	UART(const char *SymName,unsigned int baud);
	~UART();
};

#endif // _H_UART
