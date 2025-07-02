import { Controller, Get, Query } from '@nestjs/common';
import { MainusersService } from './mainusers.service';
import { ParseIntPipe } from 'src/middleware/pipe';

@Controller('mainusers')
export class MainusersController {
  constructor(private readonly mainusersService: MainusersService) {}

  @Get()
  findAll(){
    return this.mainusersService.findAll()
  }
}
