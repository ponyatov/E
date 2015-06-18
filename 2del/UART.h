#ifndef _H_UART
#define _H_UART

class UART {
	int baud;
	HANDLE PortHandle;
	static const int TIMEOUT;
public:
	const char *SymName;
	UART(const char *SymName,int baud);
	~UART();
	bool send(char *buf,unsigned int size);
};

#endif // _H_UART
